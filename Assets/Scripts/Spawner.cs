using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject obstacle1Prefab;// The obstacle prefab to spawn
    public GameObject obstacle2Prefab;
    public Transform lane1Position;        // Position for lane 1
    public Transform lane2Position;        // Position for lane 2
    public float spawnInterval = 2f;       // Time between each spawn

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnObstacles();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnObstacles()
    {
        // Randomly choose lanes for two obstacles
        bool isFirstInLane1 = Random.value > 0.5f;

        Vector3 spawnPos1 = isFirstInLane1 ? lane1Position.position : lane2Position.position;
        Vector3 spawnPos2 = isFirstInLane1 ? lane2Position.position : lane1Position.position;

        // Instantiate obstacles at the selected positions
        Instantiate(obstacle1Prefab, spawnPos1, Quaternion.identity);
        Instantiate(obstacle2Prefab, spawnPos2, Quaternion.identity);
    }
}
