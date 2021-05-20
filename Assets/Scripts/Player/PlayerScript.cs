using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=============================================
// The main player script
//=============================================

public class PlayerScript : StateMachine
{
    [Header("SubScripts")]
    [SerializeField] private PlayerInputScript PlayerInputScript;
    [SerializeField] private PlayerMovementScript PlayerMovementScript;
    [Space]
    [SerializeField] internal Vector2 Direction;
    [Space]

    [Header("Ground")]
    [SerializeField] internal bool isGrounded;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;

    [Header("Ground")]
    [SerializeField] string currentState;
    [SerializeField] internal bool isRecovered = true;
    [SerializeField] internal float normalizedTime;
    
    internal State state;
    internal Animator Animator;
    internal SpriteRenderer SpriteRenderer;
    internal Rigidbody2D Rb2d;
    internal float AnimationLength;
    internal float AnimationNormalizedTime;

    // Awake is called before Start
    private void Awake() => GetComponents();

    private void Start() => new Idle (this, PlayerMovementScript);


    // Update is called once per frame
    private void Update()
    {
        CheckGround();
        FlipSprite();

        state = State; // Because State is protected in StateMachine Class
        currentState = State.ToString();

        normalizedTime = Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    
    private void GetComponents()
    {
        PlayerInputScript = GetComponent<PlayerInputScript>();
        PlayerMovementScript = GetComponent<PlayerMovementScript>();

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
        }
        else if (Rb2d.velocity.x < -0.1f)
        {
            SpriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
    }
}
