using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameObject checkpoint;
    public float timetofirstCheckpoint = 60f;

    private float gameTime = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= timetofirstCheckpoint &&   !checkpoint.activeInHierarchy)
        {
            ActivateCheckpoint();
        }
    }

    void ActivateCheckpoint()
    {
        checkpoint.SetActive(true);
    }
}
