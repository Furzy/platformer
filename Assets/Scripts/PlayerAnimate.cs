using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Animator anim;
    private PlayerProperties pp;
    private SpriteRenderer sp;

    public bool facingRight = true;
    [HideInInspector]
    public bool wantWalk = false;
    public bool isWalking = false;
    [HideInInspector]
    public bool wantRun = false;
    public bool isRunning = false;
    [HideInInspector]
    public bool wantCrouch = false;
    public bool isCrouching = false;
    [HideInInspector]
    public bool wantNJump = false;
    public bool isNJumping = false;


    // Start is called before the first frame update
    private void Start()
    {
		anim = GetComponent<Animator>();
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        sp = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    private void Update()
    {
        CheckAnimate();
        Animate();
        Flip();
    }

    private void CheckAnimate()
    {
        if (pp.isGrounded)
        {
            if (wantCrouch)
            {
                isCrouching = true;
                isRunning = false;
                isWalking = false;
            }
            else if (wantWalk)
            {
                isWalking = true;
                isCrouching = false;
                isWalking = false;
            }
            else if (wantRun)
            {
                isRunning = true;
                isCrouching = false;
                isWalking = false;
            }
            isNJumping = false;
        }

        if (!pp.isGrounded)
        {
            isWalking = false;
            isCrouching = false;
            isRunning = false;
        }
    }
    private void Animate()
	{
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isWalking", isWalking);
        anim.SetBool("isCrouching", isCrouching);
        anim.SetBool("isNJumping", isNJumping);        
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


