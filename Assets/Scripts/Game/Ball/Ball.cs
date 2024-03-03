using System;
using UnityEngine;

[RequireComponent(typeof(Collision2D))]
public class Ball : MonoBehaviour
{
    public EnumBalls ballType;
    public bool explosive = false;

    private bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (explosive)
        {
            if (collision.gameObject.GetComponent<Ball>() != null)
            {
                Destroy(collision.gameObject);
                return;
            }
        }

        if (hasCollided)
            return;

        Ball otherBall = collision.gameObject.GetComponent<Ball>();

        if (otherBall == null || otherBall == this)
            return;

        if (otherBall.hasCollided)
            return;

        if (ballType != otherBall.ballType)
            if (!((int)ballType == 11 || (int)otherBall.ballType == 11))
                return;

        hasCollided = true;
        otherBall.hasCollided = true;

        int newSize = otherBall.ballType > ballType ? (int)ballType : (int)otherBall.ballType;

        MergeBalls(gameObject, otherBall.gameObject, newSize + 1);
    }

    private void MergeBalls(GameObject gameObject1, GameObject gameObject2, int newSize)
    {
        Vector3 newPos = gameObject.transform.position;
        
        Destroy(gameObject1);
        Destroy(gameObject2);

        if (newSize < (Enum.GetValues(typeof(EnumBalls)).Length - 1))
        {
            SpawnBall(newPos, newSize);
        }
        
        ScoreManager.Instance.IncreaseScore(((int)ballType + 1) * 2);
    }

    private void SpawnBall(Vector3 spawnPos, int size)
    {
        Instantiate(SpawnManager.Instance.BallPrefabs[size], spawnPos, Quaternion.identity);
    }
}
