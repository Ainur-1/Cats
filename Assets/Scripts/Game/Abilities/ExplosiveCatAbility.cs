using UnityEngine;
using UnityEngine.UI;

public class ExplosiveCatAbility : MonoBehaviour
{
    [SerializeField] private Button abilityButton;

    void Start()
    {
        abilityButton.onClick.AddListener(ApplyAbility);
    }

    void ApplyAbility()
    {
        GameObject ball = SpawnManager.Instance.Ball;
        ball.GetComponent<Ball>().explosive = true;
    }
}
