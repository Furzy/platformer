using System.Collections;
using UnityEngine;

//=============================================
// The main player script
//=============================================

public class PlayerScript : StateMachine
{

    //================================================
    // Inspector stuff
    // 
        [Header("State")]
        [SerializeField] private string _currentState;
        [SerializeField] private bool _isRecovered;
        [SerializeField] private bool _isGrounded;
        
        [Header("Movement")]
        [SerializeField] private Vector2 _Direction;
        [SerializeField] private Vector2 Velocity;
        [SerializeField] private float _doubleKeySpeed;
        [SerializeField] private float _walkingMoveSpeed;
        [SerializeField] private float _runningMoveSpeed;

        [Header("Jumping")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _runJumpForce;
    //   
    //================================================

    public Vector2 Direction {get; protected set;}

    public bool isGrounded {get; protected set;} = true;
    public bool isFacingRight {get; protected set;} = true;
    public bool isRecovered {get; protected set;} = true;

    public float walkingMoveSpeed {get; protected set;} = 2f;
    public float runningMoveSpeed {get; protected set;} = 5f;
    public float jumpForce {get; protected set;} = 4.25f;
    public float runJumpForce {get; protected set;} = 4.6f;
    public float doubleKeySpeed {get; protected set;} = 0.3f;

    private Transform groundCheckPoint;
    private LayerMask groundLayer;
    private Vector2 groundCheckSize;

    internal Animator Animator;
    internal SpriteRenderer SpriteRenderer;
    internal Rigidbody2D Rb2d;

    private void Awake() => GetComponents();

    private void Start() => new Idle (this);

    private void Update()
    {
        CheckWorld();
        Inputs();
        FlipSprite();
        UpdateInspector();
    }

    private void GetComponents()
    {
        groundCheckPoint = GameObject.Find("GroundCheckPoint").transform;
        groundLayer = LayerMask.GetMask("Ground");
        groundCheckSize = new Vector2(0.8f, 0.01f);
        
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rb2d = GetComponent<Rigidbody2D>();
    }

    private void CheckWorld()
    {
        Velocity = Rb2d.velocity;
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
    } 

    private void Inputs()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FlipSprite()
    {
        if (Rb2d.velocity.x > 0.1f) 
        {
            SpriteRenderer.flipX = false;
            isFacingRight = true;
        }
        else if (Rb2d.velocity.x < -0.1f)
        {
            SpriteRenderer.flipX = true;
            isFacingRight = false;
        }
    }

    private void UpdateInspector()
    {
        _currentState = PlayerInputState.ToString();
        _isRecovered = isRecovered;
        _isGrounded = isGrounded;
        _doubleKeySpeed = doubleKeySpeed;
        _walkingMoveSpeed = walkingMoveSpeed;
        _runningMoveSpeed = runningMoveSpeed;
        _jumpForce = jumpForce;
        _runJumpForce = runJumpForce;
        _Direction = Direction;
    }

    public void SetRecovery(bool _bool) // Used in states to change recovery
    {   
        isRecovered = _bool;
    }

    private void OnDrawGizmosSelected() // To visually represent the GroundCheck on Scene window in Unity
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
    }
}
