using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemoverAbility : MonoBehaviour
{
    [SerializeField] private Button abilityButton;

    void Start()
    {
        abilityButton.onClick.AddListener(ApplyAbility);
    }

    void ApplyAbility()
    {
        StartCoroutine(BlinkAndDestroy(GetBiggestBall())); 
    }

    private GameObject GetBiggestBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject biggestBallObject = null;
        int biggestBallSize = int.MinValue;

        foreach (GameObject ball in balls)
        {
            Ball ballScript = ball.GetComponent<Ball>();
            if (ballScript == null) continue;

            int ballSize = (int)ballScript.ballType;

            if (ballSize > biggestBallSize)
            {
                biggestBallSize = ballSize;
                biggestBallObject = ball;
            }

        }

        return biggestBallObject;
    }

    IEnumerator BlinkAndDestroy(GameObject obj)
    {
        Color originalColor = obj.GetComponent<Renderer>().material.color;
        Color transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        float duration = 1.5f;
        float blinkDuration = 0.3f;
        int blinkCount = Mathf.CeilToInt(duration / blinkDuration / 2);
        for (int i = 0; i < blinkCount; i++)
        {
            obj.GetComponent<Renderer>().material.color = transparentColor;
            yield return new WaitForSeconds(blinkDuration);

            obj.GetComponent<Renderer>().material.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }

        Destroy(obj);
    }

}
