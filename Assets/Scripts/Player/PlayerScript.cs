using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=============================================
// The main player script
//=============================================

public class PlayerScript : MonoBehaviour
{
    //Store a reference to all sub player scripts
    [Header("SubScripts")]
    [SerializeField]
    internal PlayerInputScript playerInputScript;
    [SerializeField]
    internal PlayerMovementScript playerMovementScript;
    [SerializeField]
    internal PlayerCollisionScript playerCollisionScript;
    [SerializeField]
    internal PlayerAnimationScript playerAnimationScript;

    //For Ground Check
    [Header("Ground")]
    public bool isGrounded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] LayerMask groundLayer;


    [Header("Components")]
    internal Animator animator;
    internal SpriteRenderer spriteRenderer;
    internal Rigidbody2D rb2d;

    [Header("Other")]
    public AnimationState currentState;
    public Vector2 direction;

    
    // Awake is called before Start
    private void Awake()
    {
        print("PlayerScript Awake");

        playerInputScript = GetComponent<PlayerInputScript>();
        playerMovementScript = GetComponent<PlayerMovementScript>();
        playerCollisionScript = GetComponent<PlayerCollisionScript>();
        playerAnimationScript = GetComponent<PlayerAnimationScript>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWorld();
        FlipSprite();
    }

    internal void CheckWorld()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
    }

    internal void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
    }

    internal void FlipSprite()
    {
        if (rb2d.velocity.x > 0.1f) 
        {
            spriteRenderer.flipX = false;
        }
        else if (rb2d.velocity.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    internal void ChangeState(AnimationState newState)
    {
        if(newState != currentState)
        {
            //animator.Play(newState.ToString()); // Need to make sure .toString works in this context
            currentState = newState;
        }
           
    }

}
