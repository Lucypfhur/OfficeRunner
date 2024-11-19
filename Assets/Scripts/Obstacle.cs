using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float obstacleSpeed;
    private float objectThreshold = 15f;

    // Start is called before the first frame update
   
    public void SetSpeed(float speed)
    {
        obstacleSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
        DestroyObject();
    }
    void MoveObstacle()
    {
        transform.Translate(Vector3.right * obstacleSpeed * Time.deltaTime);
    }
    void DestroyObject()
    {
        if (transform.position.x > objectThreshold)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            boxCollider.enabled = false;
            meshRenderer.enabled = false;

            Spawner spawner = FindObjectOfType<Spawner>();
            if (spawner != null)
            {
                spawner.TriggerSpeedReduction();
            }

            else
            {
                Debug.LogError("ObstacleSpawner not found in the scene.");
            }

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BoxCollider Collider = GetComponent<BoxCollider>();
            MeshRenderer Renderer = GetComponent<MeshRenderer>();
            Collider.enabled = false;
            Renderer.enabled = false;
        }
    }


}  



