using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> spawnPrefab;
    public Transform spawnPos;
    private float spawnInterval = 2f;
    private float IntervalinSpawn = 3f;


    void Start()
    {
        InvokeRepeating("PrefabToSpawn", spawnInterval,IntervalinSpawn);
    }

   
   
    private void PrefabToSpawn()
    {
        if (spawnPrefab.Count == 0) return;

        int randomIndex = Random.Range(0, spawnPrefab.Count);

        GameObject prefabTospawn = spawnPrefab[randomIndex];
        Instantiate(prefabTospawn, spawnPos.position, Quaternion.identity);
    }
}
