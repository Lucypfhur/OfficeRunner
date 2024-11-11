using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float objectThreshold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();   
        DestroyObject();
    }
    void MoveObstacle()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
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
            boxCollider.enabled = false;
        }
    }
}
