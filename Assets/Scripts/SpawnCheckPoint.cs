using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckPoint : MonoBehaviour
{
    public GameObject checkPointPrefab;
    [SerializeField] private float spawnInterval;
    public Vector2 spawnPosition;

    private float timer; 
    // this script is only valid till checkpoint 
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnCheckpoint();
            timer = spawnInterval;
        }
    }

    private void SpawnCheckpoint()
    {
        Instantiate(checkPointPrefab, spawnPosition, Quaternion.identity);
    }
}
