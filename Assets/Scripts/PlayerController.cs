using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float switchSpeed = 10f;
    [SerializeField]
    private float leftLaneZ = -3f;
    [SerializeField]
    private float rightLaneZ = 0f;
    [SerializeField]
    private Animator anim;

   
    private float originalScaleY;
    private bool isCrouching;
    private float crouchScaleY = 0.5f;
    private bool isGrounded = true;
    private bool isOnRightLane = true;
    private bool islaneSwitchOn;

    private Vector3 targetPosition;

    private LifeSystem lifeSystem;


    private Rigidbody rBody;
    private Collider playerCollider;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        lifeSystem = FindObjectOfType<LifeSystem>();
        playerCollider = GetComponent<Collider>();
        originalScaleY = transform.localScale.y;
        targetPosition = transform.position;
        anim= GetComponent<Animator>();

        if (enemy == null)
        {
            Debug.Log("Enemy controller is not Assigned");
        }
    }

    void Update()
    {
        HandleJump();
        HandleCrouch();
        HandleSwitching();
        TransitionInLanes();

    }
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Debug.Log("up arrow pressed");
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Player is now in the air

            anim.SetBool("Jump", true);
            anim.SetBool("Crouch", false);
            anim.SetBool("Idle", false);
        }
        else if (isGrounded)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Idle", true);
        }
    }
    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            if (!isCrouching)
            {

                transform.localScale = new Vector3(transform.localScale.x, crouchScaleY, transform.localScale.z); // Start crouching by reducing the player's scale along Y-axis
                anim.SetBool("Crouch", true);
                anim.SetBool("Jump", false);
                anim.SetBool("Idle", false);
                isCrouching = true;
            }
        }
        else if (isCrouching)
        {

            transform.localScale = new Vector3(transform.localScale.x, originalScaleY, transform.localScale.z); // Stop crouching by resetting the player's scale
            isCrouching = false;
            anim.SetBool("Crouch", false);
            anim.SetBool("Idle", true);
        }
    }

    void HandleSwitching()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && islaneSwitchOn && isOnRightLane)
        {
            Debug.Log("Left Arrow pressed");
            targetPosition = new Vector3(transform.position.x, transform.position.y, leftLaneZ);
            isOnRightLane = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && islaneSwitchOn && !isOnRightLane)
        {
            Debug.Log("Right Arrow Pressed"); 
            targetPosition = new Vector3(transform.position.x, transform.position.y, rightLaneZ);
            isOnRightLane = true;
        }

    }

    void TransitionInLanes()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, targetPosition.z),
                switchSpeed * Time.deltaTime);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle") )
        {
           
            lifeSystem.TakeDamage(1);
            enemy.MoveCloser();

        }
    }
    
    public void EnableLaneSwitching()
    {
        islaneSwitchOn = true; // Enable lane switching ability
        Debug.Log("Lane switching enabled.");
    }
}
