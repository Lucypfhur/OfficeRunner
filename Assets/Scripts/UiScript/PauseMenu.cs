using Unity.VisualScripting;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Resume();
            }
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 1f;
        isPaused = true;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}