using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;

    private float originalScaleY;
    private bool isCrouching;
    private float crouchScaleY = 0.5f;
    private bool isGrounded = true;

    private LifeSystem lifeSystem;


    private Rigidbody rBody;
    private Collider playerCollider;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        lifeSystem = FindObjectOfType<LifeSystem>();
        playerCollider = GetComponent<Collider>();
        originalScaleY = transform.localScale.y;
    }

    void Update()
    {
        HandleJump();
        HandleCrouch();
    }
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Debug.Log("up arrow pressed");
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Player is now in the air
        }
    }
    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            if (!isCrouching)
            {

                transform.localScale = new Vector3(transform.localScale.x, crouchScaleY, transform.localScale.z); // Start crouching by reducing the player's scale along Y-axis
                isCrouching = true;
            }
        }
        else if (isCrouching)
        {

            transform.localScale = new Vector3(transform.localScale.x, originalScaleY, transform.localScale.z); // Stop crouching by resetting the player's scale
            isCrouching = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Collided");
            lifeSystem.TakeDamage(1);

        }
    }
}
