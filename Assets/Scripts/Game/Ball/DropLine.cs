using UnityEngine;

public class DropLine : MonoBehaviour
{
    [SerializeField] private GameObject dropLinePrefab;
    private GameObject dropLine;
    private GameObject ball;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateDropLine();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(dropLine);
        }
    }

    private void CreateDropLine()
    {
        ball = SpawnManager.Instance.Ball;
        Vector3 position = new Vector3(ball.transform.position.x, ball.transform.position.y - 4.5f, 0);
        dropLine = Instantiate(dropLinePrefab, position, Quaternion.identity);
        dropLine.transform.SetParent(ball.transform);
    }
}
