using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Animator anim;
    private PlayerProperties pp;

    public float waitTime = 0.117f;
    public bool doneWaiting = false;


    // Start is called before the first frame update
    private void Start()
    {
		anim = GetComponent<Animator>();
        pp = GameObject.FindObjectOfType<PlayerProperties>();

    }

    // Update is called once per frame
    private void Update()
    {
        Animate();
        Flip();

    }

    private void Animate()
	{
		anim.SetBool("isRunning", pp.isRunning);
		anim.SetBool("isWalking", pp.isWalking);
        anim.SetBool("isCrouching", pp.isCrouching);
        
	}

    private void Flip()
    {
        if (pp.rb.velocity.x > 0.1f) 
        {
            pp.sp.flipX = false;
        }
        else if (pp.rb.velocity.x < -0.1f)
        {
            pp.sp.flipX = true;
        }
    }

    // private void SetTriggers()
    // {
    //     if(pp.isTurning)
    //     {    
    //         anim.SetTrigger("isTurning");
    //         // Wait until waitTime is below or equal to zero.
    //         if(waitTime > 0) {
    //             waitTime -= Time.deltaTime;
    //         } else {
    //             // Done.
    //             doneWaiting = true;
    //         }
            
    //         // Only proceed if doneWaiting is true.
    //         if(doneWaiting) {
    //             transform.Rotate(0, 180, 0);
    //             pp.facingRight = !pp.facingRight;
    //             pp.isTurning = false;
    //             doneWaiting = false;
    //             waitTime = 0.117f;
    //         }

    //     }

    // }
}


