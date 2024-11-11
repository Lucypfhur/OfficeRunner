using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*public List<GameObject> spawnPrefab;
    public Transform spawnPos;
    private float spawnInterval = 2f;
    private float IntervalinSpawn = 3f;


    void Start()
    {
        InvokeRepeating("PrefabToSpawn", spawnInterval, IntervalinSpawn);
    }

    private void PrefabToSpawn()
    {
        if (spawnPrefab.Count == 0) return;

        int randomIndex = Random.Range(0, spawnPrefab.Count);

        GameObject prefabTospawn = spawnPrefab[randomIndex];
        Instantiate(prefabTospawn, spawnPos.position, Quaternion.identity);
    } */

    public List<GameObject> obstaclePrefabs;
    public Transform spawnPosition;
    public float[] laneZPositions = { -2f, 0f }; // Array for different Z positions
    public float leftLaneX = -2f;
    public float rightLaneX = 2f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    public float spawnYPosition = 5f;

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacles();
            ScheduleNextSpawn();
        }
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnObstacles()
    {
        if (obstaclePrefabs.Count == 0) return;

        foreach (float laneZ in laneZPositions)
        {
            float laneX = Random.Range(0, 2) == 0 ? leftLaneX : rightLaneX;
            Vector3 spawnPos = new Vector3(laneX, spawnYPosition, laneZ);
            int randomIndex = Random.Range(0, obstaclePrefabs.Count);
            Instantiate(obstaclePrefabs[randomIndex], spawnPos, Quaternion.identity);
        }
    }
}
