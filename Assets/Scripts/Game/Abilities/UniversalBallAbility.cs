using System;
using UnityEngine;
using UnityEngine.UI;

public class UniversalBallAbility : MonoBehaviour
{
    [SerializeField] private Button abilityButton;
    [SerializeField] private GameObject abilityBall;

    void Start()
    {
        abilityButton.onClick.AddListener(ApplyAbility);
    }

    private void ApplyAbility()
    {
        SpawnManager.Instance.ChangeBall();
    }
}
