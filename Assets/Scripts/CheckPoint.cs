using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float timetofirstCheckpoint = 60f;
    public float messageDisplayTime = 3f;
    public float ObstaclePauseTime = 3f;

    private bool checkpointReached = false;
    private float gameTime;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
