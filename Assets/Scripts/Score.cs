using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0f;
    private float scoreRate = 10f;

    public TextMeshProUGUI scoretext;

    private LaneSpawner laneSpawner;
    // Start is called before the first frame update
    void Start()
    {
         laneSpawner = FindObjectOfType<LaneSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        DisplayText();
        
         Checkpoint1();
        
    }

    void UpdateText()
    {
        score += scoreRate * Time.deltaTime;
    }

    void DisplayText()
    {
        scoretext.text =  "Score " + Mathf.FloorToInt(score).ToString();
    }

    void Checkpoint1()
    {
        if (score >= 100f && laneSpawner!= null)
        {
            laneSpawner.AddLane();


        }
    }
}
