using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject Lane2Prefab;
    public Transform lanePosition;

    private bool isLaneAdded = false;

    private Spawner obstacleSpawner;
    private PlayerController player;

    private void Start()
    {
        obstacleSpawner = FindObjectOfType<Spawner>();
        player = FindObjectOfType<PlayerController>();

    }
    public void AddLane()
    {
        if (!isLaneAdded)
        {


            Instantiate(Lane2Prefab, lanePosition.position, Quaternion.identity);
            isLaneAdded = true;
            Debug.Log("Lan2 Added");

            if (obstacleSpawner != null)
            {
                obstacleSpawner.Lane2SpawnPos();// Spawns obstacles on lane 2 
            }
            if (player != null)
            {
                player.EnableLaneSwitching();
            }
        }
    }
}
