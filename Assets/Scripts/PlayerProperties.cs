using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    //For Movement
    [Header("Movement")]
    public Vector2 velocity;
    public bool facingRight = true;
    public bool isWalking = false;
    public float groundedMoveSpeed = 10f;
    public bool isRunning = false;
    public float doubleTapSpeed = 0.3f;
    public float runningMoveSpeed = 10f;
    public bool isCrouching = false;

    //For Jumping
    [Header("Jumping")]
    public bool isNJumping = false;
    public float jumpForce = 0.3f;

    //For Ground Check
    [Header("Ground")]
    public bool isGrounded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] LayerMask groundLayer;
    
    //For Physics
    [Header("Physics")]
    [SerializeField] float fallMultiplier = 22f;
    [SerializeField] float lowJumpMultiplier = 14f;
    [SerializeField] float groundedMultiplier = 8f;

    [Header("Others")]
    public Vector2 direction;
    public Rigidbody2D rb;
    public SpriteRenderer sp;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        sp = GetComponent<SpriteRenderer>();  
    }

    private void Update()
    {
        Inputs();
        CheckWorld();
    }

    private void FixedUpdate()
    {
        ChangePhysics();
        velocity = rb.velocity;
    }

    private void Inputs()
    {
        getDirection();
        
        void getDirection()
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        }
    }
    private void CheckWorld()
    {
        checkIfGrounded();

        void checkIfGrounded()
        {
            isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        }
    }
    private void ChangePhysics()
    {
        if (rb.velocity.y <= 0)
        {
            rb.gravityScale = fallMultiplier;
        } 
        else if (rb.velocity.y > 0 && direction.y == 0) 
        {
            rb.gravityScale = lowJumpMultiplier;
        } else {
            rb.gravityScale = groundedMultiplier;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
    }
}
