using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        
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
