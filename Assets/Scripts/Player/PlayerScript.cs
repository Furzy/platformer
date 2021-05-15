using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=============================================
// The main player script
//=============================================

public class PlayerScript : StateMachine
{
    //Store a reference to all sub player scripts
    [Header("SubScripts")]
    [SerializeField] private PlayerInputScript PlayerInputScript;
    [SerializeField] private PlayerMovementScript PlayerMovementScript;

    //For Ground Check
    internal bool isGrounded;
    [Header("Ground")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;

    [Header("Others")]
    [SerializeField] internal State state;
    [SerializeField] internal Vector2 Direction;
    
    internal Animator Animator;
    internal SpriteRenderer SpriteRenderer;
    internal Rigidbody2D Rb2d;

    // Awake is called before Start
    private void Awake()
    {
        Debug.Log("PlayerScript Awake");

        GetComponents();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGround();
        FlipSprite();

        state = State; // For the Unity Inspector
    }
    
    private void GetComponents()
    {
        PlayerInputScript = GetComponent<PlayerInputScript>();
        PlayerMovementScript = GetComponent<PlayerMovementScript>();

        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rb2d = GetComponent<Rigidbody2D>();
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer);
    }

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
