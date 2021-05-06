using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Animator anim;
    private PlayerProperties pp;
    private SpriteRenderer sp;

    public bool facingRight = true;

    // Walking
    [HideInInspector]
    public bool wantWalk = false;
    public bool isWalking = false;

    // Running
    [HideInInspector]
    public bool wantRun = false;
    public bool isRunning = false;

    // Crouching
    [HideInInspector]
    public bool wantCrouch = false;
    public bool isCrouching = false;

    // N Jumping
    [HideInInspector]
    public bool wantNJump = false;
    public bool startNJumping = false;
    public bool endNJumping = false;
    
    // B Jumping
    [HideInInspector]
    public bool wantBJump = false;
    private bool startBJumping = false;
    private bool endBJumping = false;

    // F Jumping
    [HideInInspector]
    public bool wantFJump = false;
    private bool startFJumping = false;
    private bool endFJumping = false;

    public bool stillJumping = false;



    // Start is called before the first frame update
    private void Start()
    {
		anim = GetComponent<Animator>();
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        sp = GetComponent<SpriteRenderer>();  
    }

    private void Update()
    {
        InitAnimate();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        InitJumpAnimate();
        Animate();
        Flip();
    }

    private void InitAnimate()
    {
        if (pp.isGrounded)
        {
            if (wantCrouch) // Crouching
            {
                isCrouching = true;
                isRunning = false;
                isWalking = false;
            }
            else if (wantWalk) // Walking
            {
                isWalking = true;
                isCrouching = false;
                isRunning = false;
            }
            else if (wantRun) // Running
            {
                isRunning = true;
                isCrouching = false;
                isWalking = false;
            }
            else // Idle
            {
                isRunning = false;
                isCrouching = false;
                isWalking = false;
            }
        }
    }

    private void InitJumpAnimate()
    {
        if (!pp.isGrounded)
        {
            isWalking = false;
            isCrouching = false;
            isRunning = false;

            // Neutral Jump
            if (pp.rb.velocity.x == 0f) 
            {
                if (pp.rb.velocity.y > 0.1f) // Start
                {
                    startNJumping = true;

                    stillJumping = false;
                    endNJumping = false;
                }
                else if (pp.rb.velocity.y < 0.1f && pp.rb.velocity.y > -0.1f) // Start
                {
                    stillJumping = true;

                    startNJumping = false;
                    endNJumping = false;

                }
                else if (pp.rb.velocity.y < -0.1f) // Start
                {
                    endNJumping = true;

                    startNJumping = false;
                    stillJumping = false;
                }

            
            }
        }
    }


    private void Animate()
	{
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isWalking", isWalking);
        anim.SetBool("isCrouching", isCrouching);
        anim.SetBool("startNJumping", startNJumping);        
        anim.SetBool("stillJumping", stillJumping);        
        anim.SetBool("endNJumping", endNJumping);        
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


