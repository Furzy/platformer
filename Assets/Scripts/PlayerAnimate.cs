using System.Collections;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public enum AnimationState 
    {
        PLAYER_IDLE, 
        PLAYER_WALK, 
        PLAYERWALKBACK, 
        PLAYER_RUN, 
        PLAYER_BACKDASH,
        PLAYER_CROUCHSTART,
        PLAYER_CROUCHING,
        PLAYER_CROUCHEND,
        PLAYER_BJUMPSTART,
        PLAYER_BJUMPEND,
        PLAYER_NJUMPSTART,
        PLAYER_NJUMPEND,
        PLAYER_FJUMPSTART,
        PLAYER_FJUMPEND
    }

    [HideInInspector]
    public Animator anim;
    public AnimationState currentAnimationState = AnimationState.PLAYER_IDLE;

    private PlayerProperties pp;
    private SpriteRenderer sp;
    private PlayerGroundMovement pgm;

    public bool facingRight = true;
    public bool animationPlaying = false;
    public float animationLength = 0f;

    private bool isKeyHolding = false;
    private bool keyDown = false;
    private bool keyHold = false;


    // Start is called before the first frame update
    private void Start()
    {
		anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();  
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pgm = GameObject.FindObjectOfType<PlayerGroundMovement>();
    }

    private void Update()
    {
        SetNewAnimState();
        ChangeCurrentAnimState();
        Flip();
    }

    private void SetNewAnimState()
	{
        // On Ground
        if (pp.isGrounded)
        {
            // No horizontal input
            if (Mathf.Abs(pp.direction.x) < 0.1f)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow)) // Crouch Start
                {
                    currentAnimationState = AnimationState.PLAYER_CROUCHSTART;
                }
                else if (Input.GetKeyUp(KeyCode.DownArrow)) // While Rising
                {
                    currentAnimationState = AnimationState.PLAYER_CROUCHEND;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow)) // Neutral Jumping
                {
                    currentAnimationState = AnimationState.PLAYER_NJUMPSTART;
                }
                else if (Mathf.Abs(pp.direction.y) < 0.1f) // Idle
                {
                    currentAnimationState = AnimationState.PLAYER_IDLE;
                }
            }
            // Horizontal input
            else 
            {
                if (pgm.isDoubleTapping) // Running
                {
                    currentAnimationState = AnimationState.PLAYER_RUN;
                }
                else // Walking
                {
                    currentAnimationState = AnimationState.PLAYER_WALK;
                }
            }
        }
        // In Air – WIP
        else
        {
        }
	}

    private void ChangeCurrentAnimState()
    {
        if (!animationPlaying)
        {

            switch (currentAnimationState)
            {
                case AnimationState.PLAYER_CROUCHSTART:
                    anim.Play("Player_CrouchStart");
                    animationLength = anim.GetCurrentAnimatorStateInfo(0).length - 0.8f;
                    animationPlaying = true;
                    StartCoroutine("WaitForAnimationEnd", animationLength);
                    break;
                case AnimationState.PLAYER_CROUCHING:
                    anim.Play("Player_Crouching");
                    break;
                default:
                    anim.Play("Player_Idle");
                    break;
            }
        }
    }

    IEnumerator WaitForAnimationEnd(float _animationLength)
    { 
        yield return new WaitForSeconds(_animationLength); 
        currentAnimationState = AnimationState.PLAYER_CROUCHING;
        animationPlaying = false;
    }


    private void Flip()
    {
        if (pp.rb.velocity.x > 0.1f) 
        {
            sp.flipX = false;
        }
        else if (pp.rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
        }
    }

    // private void HoldKey(KeyCode _key, float _animationLength)
    // {
    //     if (!keyDown) 
    //     { 
    //         if (Input.GetKeyDown(_key)) 
    //         { 
    //             StartCoroutine (CheckHoldKey()); 
    //         } 
    //     } 
    //     else 
    //     { 
    //         if (Input.GetKey(_key) && !Input.GetKeyDown(_key)) 
    //         { 
    //             keyHold = true; 
    //         } 
    //     } 
        
    //     if (keyHold) 
    //     { 
    //         isKeyHolding = true;
    //     } 
        
    //     if(Input.GetKeyUp(_key))
    //     { 
    //         keyHold = false; 
    //         isKeyHolding = false;
    //     } 

    //     IEnumerator CheckHoldKey()
    //     { 
    //         keyDown = true; 
    //         yield return new WaitForSeconds(_animationLength); 
    //         keyDown = false; 
    //     }
    // }

}


