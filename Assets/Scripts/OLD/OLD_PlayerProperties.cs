using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 velocity;
    [HideInInspector]
    public Rigidbody2D rb;

    //For Ground Check
    [Header("Ground")]
    public bool isGrounded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] LayerMask groundLayer;

    
    //For Physics
    // [Header("Physics")]
    // [SerializeField] float fallMultiplier = 1f;
    // [SerializeField] float lowJumpMultiplier = 1f;
    // [SerializeField] float groundedMultiplier = 1f;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {

        Inputs();
        CheckWorld();
    }

    private void FixedUpdate()
    {
        // ChangePhysics();
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
        velocity = rb.velocity;


        void checkIfGrounded()
        {
            isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
        }
    }
    // private void ChangePhysics()
    // {
    //     if (rb.velocity.y <= 0)
    //     {
    //         rb.gravityScale = fallMultiplier;
    //     } 
    //     else if (rb.velocity.y > 0 && direction.y == 0) 
    //     {
    //         rb.gravityScale = lowJumpMultiplier;
    //     } else {
    //         rb.gravityScale = groundedMultiplier;
    //     }
    // }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
    }
}
