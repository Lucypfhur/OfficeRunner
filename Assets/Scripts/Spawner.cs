using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  
    public Transform[] spawnPoints;       
    public float spawnInterval = 2f;     

    private void Start()
    {
        StartCoroutine(SpawnObstaclesWithDelay());
    }

    IEnumerator SpawnObstaclesWithDelay()
    {
        while (true)
        {
            SpawnObstacles();   
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    void SpawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacleToSpawn = obstaclePrefabs[obstacleIndex];

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnPointIndex];

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
