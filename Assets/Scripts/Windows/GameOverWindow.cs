using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScoreManager scoreManager;

    public void UpdateScoreText()
    {

        scoreText.text = "Score: " + scoreManager.GetScore();
    }
}
