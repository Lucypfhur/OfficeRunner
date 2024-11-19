using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
  
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
       
       
           
       
    }

    public void TriggerGameOver()
    {
      
       
           SceneManager.LoadScene(3); // Show the Game Over screen
           Time.timeScale = 0f; // Pause the game
       
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }

    public void StartGame()
    {
        backgroundMusic.Play();
    }

    public void GameOver()
    {
        backgroundMusic.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
