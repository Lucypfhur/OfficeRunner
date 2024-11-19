using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] collectiblePrefabs;
    public List<Transform> spawnPoints = new List<Transform>();
    public Transform Lane2Spawnpoints;// spawn position for lane 2 
    public float originalInterval = 2f;
    private float reducedInterval = 4f;
    private float currentInterval;
    private float collectibleChance = 0.1f;// chance to spawn the collectable



    public float originalSpeed = 3f;   
    public float reducedSpeed = 1f;     
    public float slowDuration = 5f;     

    private float currentSpeed;         
    private bool isSpeedReduced = false; 

    private List<Obstacle> activeObstacles = new List<Obstacle>(); // Track active obstacles


    private void Start()
    {
        currentSpeed = originalSpeed;
        currentInterval = originalInterval;
        StartCoroutine(SpawnObstaclesWithDelay());
    }

    IEnumerator SpawnObstaclesWithDelay()
    {
        while (true)
        {
            SpawnObstacles();   
            yield return new WaitForSeconds(currentInterval); 
        }
    }

    void SpawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacleToSpawn = obstaclePrefabs[obstacleIndex];

        int spawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[spawnPointIndex];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity);

        Obstacle obstacleScript = spawnedObstacle.GetComponent<Obstacle>();
        if (obstacleScript != null)
        {
           // Working
            obstacleScript.SetSpeed(currentSpeed);
            activeObstacles.Add(obstacleScript);
        }
        

        if (Random.value <= collectibleChance)
        {
            SpawnCollectible(spawnPointIndex);
        }
    }

    void SpawnCollectible(int usedSpawnPointIndex)
    {
        List<int> availablePoints = new List<int>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (i != usedSpawnPointIndex)
            {
                availablePoints.Add(i);
            }
        }

        if (availablePoints.Count > 0)
        {
            int collectibleIndex = Random.Range(0, collectiblePrefabs.Length);
            int collectibleSpawnPointIndex = availablePoints[Random.Range(0, availablePoints.Count)];
            Transform collectibleSpawnPoint = spawnPoints[collectibleSpawnPointIndex];

            GameObject collectibleToSpawn = collectiblePrefabs[collectibleIndex];
            Instantiate(collectibleToSpawn, collectibleSpawnPoint.position, Quaternion.identity);
        }
    }
    public void TriggerSpeedReduction()
    {
        if (!isSpeedReduced)
        {
            StartCoroutine(DecreaseSpeed());
        }
    }

    IEnumerator DecreaseSpeed()
    {
        isSpeedReduced = true;
        currentSpeed = reducedSpeed; // Apply reduced speed
        currentInterval = reducedInterval;// adjust spawn interval
        UpdateAllObstacleSpeeds();  // Update speeds for all active obstacles
        Debug.Log("Obstacle speed reduced.");
        yield return new WaitForSeconds(slowDuration);
        currentSpeed = originalSpeed; // Restore original speed
        currentInterval = originalInterval;
        UpdateAllObstacleSpeeds();  // Update speeds for all active obstacles
        isSpeedReduced = false;
        Debug.Log("Obstacle speed restored.");
    }

    void UpdateAllObstacleSpeeds()
    {
        foreach (Obstacle obstacle in activeObstacles)
        {
            if (obstacle != null)
            {
                obstacle.SetSpeed(currentSpeed); // Update each obstacle's speed
            }
        }
    }
    public void Lane2SpawnPos()
    {
        spawnPoints.Add(Lane2Spawnpoints);// Adds position of lane 2 in the list, Obstacles will be spawned on lane 2 

    }
}
