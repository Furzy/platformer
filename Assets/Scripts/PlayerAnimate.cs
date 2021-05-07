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

    private Animator anim;
    private PlayerProperties pp;
    private SpriteRenderer sp;
    private PlayerGroundMovement pgm;

    public bool facingRight = true;
    public bool animationPlaying = false;
    public float animationDelay = 0f;

    private AnimationState currentAnimationState = AnimationState.PLAYER_IDLE;

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
        animationDelay = anim.GetCurrentAnimatorStateInfo(0).length;
        GetCurrentAnimState();
        ChangeCurrentAnimState();
        Flip();
    }

    private void GetCurrentAnimState()
	{
        // On Ground
        if (pp.isGrounded)
        {
            // No horizontal input
            if (Mathf.Abs(pp.direction.x) < 0.1f)
            {
                if (pp.direction.y < -0.1f) // Crouching
                {
                
                    currentAnimationState = AnimationState.PLAYER_CROUCHSTART;
                }
                else // Idle
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
        // In Air
        else
        {
            // No horizontal input
            if (Mathf.Abs(pp.direction.x) < 0.1f)
            {

            }
            // Horizontal input
            else 
            {

            }
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
                    animationPlaying = true;
                    StartCoroutine(animationDelayer());
                    if (!animationPlaying)
                    {
                        anim.Play("Player_Crouching");
                    }
                    break;
                default:
                    anim.Play("Player_Idle");
                    break;
            }
        }
    }

    IEnumerator animationDelayer () 
    {
        yield return new WaitForSeconds (animationDelay);
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
}


