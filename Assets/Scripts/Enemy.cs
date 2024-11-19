using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float closeDistance = 3f;
    private float resetDistance= 3f;
    private float timeLimit = 5f;
    private float followSpeed = 3f;

    private Vector3 originalPosition;// original Position of the enmey
    private bool isClose;
    private float timer = 0f;
    private int collisionCount= 0;
    private bool canCatch;

    [SerializeField]
    private GameManager gameManager;


    void Start()
    {
        originalPosition = transform.position;
    }


    void Update()
    {
        FollowPlayer();

        if (isClose)
        {
            timer += Time.deltaTime;

            if (timer > timeLimit)
            {
                ResetEnemy(); // Reset if the player avoids collisions for too long
            }
        }
    }

    void ResetEnemy()
    {
        isClose = false;
        canCatch = false; // Disable catching the player
        collisionCount = 0; // Reset collision count
        transform.position = new Vector3(originalPosition.x, transform.position.y, transform.position.z); // Move enemy back to original position

        timer = 0f;
        Debug.Log("Enemy reset.");
    }
    public void MoveCloser()
    {
        collisionCount++;
        if (collisionCount == 1)
        {
            timer = 0f;
            isClose = true;
            transform.position = new Vector3(player.position.x + closeDistance, transform.position.y,player.position.z);
            Debug.Log("Enemy moved closer after first collision.");
        }
        else if (collisionCount == 2 && timer <= timeLimit)
        {
            CatchPlayer();
        }
    }
    void FollowPlayer()
    {
        if (isClose)
        {
            // Smoothly follow the player's Z-lane position
            Vector3 targetPosition = new Vector3(player.position.x +closeDistance, transform.position.y, player.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
    private void CatchPlayer()
    {
        Debug.Log("Player Caught Game Over");
        if (gameManager != null)
        {
            gameManager.TriggerGameOver();
        }
        else
        {
            Debug.Log("GameManager reference set!");
        }
    }
}
