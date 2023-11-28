using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{

    private bool isPaused;

    public GameObject menuPausa;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pausa o tempo no jogo
        isPaused = true;
        menuPausa.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Retoma o tempo no jogo
        isPaused = false;
        menuPausa.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
