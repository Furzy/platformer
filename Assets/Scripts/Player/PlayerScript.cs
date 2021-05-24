using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=============================================
// The main player script
//=============================================

public class PlayerScript : StateMachine
{
    [Header("State")]
    [SerializeField] private string _currentState;
    [SerializeField] private bool _isRecovered;
    [SerializeField] private bool _isGrounded;
    
    private PlayerMovementScript PlayerMovementScript;

    public Vector2 Direction {get; protected set;}
    public bool isGrounded {get; protected set;}
    public bool facingRight {get; protected set;} = true;
    public bool isRecovered {get; protected set;} = true;

    public bool wantRun {get; protected set;}
    public float walkingMoveSpeed {get; protected set;}
    public float runningMoveSpeed {get; protected set;}
    public float jumpForce {get; protected set;}
    public float runJumpForce {get; protected set;}

    
    private Transform groundCheckPoint;
    private LayerMask groundLayer;
    private Vector2 groundCheckSize;

    internal Animator Animator;
    internal SpriteRenderer SpriteRenderer;
    internal Rigidbody2D Rb2d;
    internal float AnimationLength;
    internal float AnimationNormalizedTime;

    

    // Awake is called before Start
    private void Awake() => GetComponents();

    private void Start() => new Idle (this);

    // Update is called once per frame
    private void Update()
    {
        UpdateRefs();
        CheckGround();
        Inputs();
        FlipSprite();
        UpdateInspector();
    }

    private void Inputs()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void UpdateRefs()
    {
        wantRun = PlayerMovementScript.wantRun;
        walkingMoveSpeed = PlayerMovementScript.walkingMoveSpeed;
        runningMoveSpeed = PlayerMovementScript.runningMoveSpeed;
        jumpForce = PlayerMovementScript.jumpForce;
        runJumpForce = PlayerMovementScript.runJumpForce;
    }

    private void UpdateInspector()
    {
        _currentState = State.ToString();
        _isRecovered = isRecovered;
        _isGrounded = isGrounded;
    }

    private void GetComponents()
    {
        PlayerMovementScript = GetComponent<PlayerMovementScript>();

        groundCheckPoint = GameObject.Find("GroundCheckPoint").transform;
        groundLayer = LayerMask.GetMask("Ground");
        groundCheckSize = new Vector2(0.8f, 0.01f);
        
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rb2d = GetComponent<Rigidbody2D>();


    }

    private void CheckGround() => isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);

    private void FlipSprite()
    {
        if (Rb2d.velocity.x > 0.1f) 
        {
            SpriteRenderer.flipX = false;
            facingRight = true;
        }
        else if (Rb2d.velocity.x < -0.1f)
        {
            SpriteRenderer.flipX = true;
            facingRight = false;
        }
    }

    public static IEnumerator SetRecovery(bool _bool ,bool isRecovered)
    {   
        isRecovered = _bool;
        yield break;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
    }
}
