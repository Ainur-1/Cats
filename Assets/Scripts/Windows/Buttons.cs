using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;

    public void OnPlayButtonClicked()
    {
        mainMenu.SetActive(false);
    }

    public void OnPauseButtonClicked()
    {
        gameManager.TogglePause();
    }

    public void OnRestartButtonClicked()
    {
        gameManager.RestartGame();
    }

}
