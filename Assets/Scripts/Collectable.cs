using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float collectiblespeed = 3f;

    private void Update()
    {
        MoveObstacle();
    }
    
    void MoveObstacle()
    {
        transform.Translate(Vector3.right * collectiblespeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {        
           Destroy(gameObject); 
        }
    }
}
