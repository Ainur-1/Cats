using UnityEngine;
using UnityEngine.UI;

public class ShuffleAbility : MonoBehaviour
{
    [SerializeField] private Button abilityButton;
    public float bonusForce = 500f;

    void Start()
    {
        abilityButton.onClick.AddListener(ApplyAbility);
    }

    void ApplyAbility()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
                rb.AddForce(randomDirection * bonusForce);
            }
        }
    }
}
