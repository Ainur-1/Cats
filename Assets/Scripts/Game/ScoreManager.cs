using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    private static ScoreManager _instance;
    [SerializeField] private TMP_Text scoreText; 

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if (_instance == null)
                {
                    GameObject scoreManagerObject = new GameObject("ScoreManager");
                    _instance = scoreManagerObject.AddComponent<ScoreManager>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public int GetScore()
    {
        return _score;
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
    }
}
