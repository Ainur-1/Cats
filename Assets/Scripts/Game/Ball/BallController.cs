using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool _isDragging = false;
    private GameObject _ball;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }

        MoveBallWithMouse();
    }

    private void MoveBallWithMouse()
    {
        if (_isDragging)
        {
            _ball = SpawnManager.Instance.Ball;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _ball.GetComponent<Rigidbody2D>().MovePosition(new Vector2(mousePosition.x, SpawnManager.Instance.SpawnY));
        }
    }
}
