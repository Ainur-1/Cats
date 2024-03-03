using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private GameObject pauseWindow;

    public bool isPaused = false;

    public void GameOver()
    {
        gameOverWindow.GetComponent<GameOverWindow>().UpdateScoreText();
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseWindow.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
