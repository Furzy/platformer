using UnityEngine;

public class PlayerGroundMovement : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;

    // Start is called before the first frame update
    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pa = GameObject.FindObjectOfType<PlayerAnimate>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //for run movement
        if (pp.isGrounded && pp.direction.x!=0 && pp.isRunning)
        {
            pp.isRunning = true;
            pp.rb.velocity = new Vector2(pp.direction.x * pp.runningMoveSpeed, pp.rb.velocity.y);

            pp.isWalking = false;
            pp.isCrouching = false;
        }
        //for crouching
        else if (pp.isGrounded && pp.direction.x == 0 && pp.direction.y == -1)
        {
            pp.isCrouching = true;
            pp.rb.velocity = new Vector2(0f, pp.rb.velocity.y);

            pp.isWalking = false;
            pp.isRunning = false;
        }
        //for idle
        else if (pp.isGrounded && pp.direction.x == 0 && pp.direction.y == 0)
        {
            pp.isWalking = false;
            pp.isRunning = false;
            pp.isCrouching = false;
            pp.rb.velocity = new Vector2(0f, pp.rb.velocity.y);
        }
        //for walk movement
        else if (pp.isGrounded && pp.direction.x!=0 && !pp.isRunning)
        {
            pp.rb.velocity = new Vector2(pp.direction.x * pp.groundedMoveSpeed, pp.rb.velocity.y);
            pp.isWalking = true;

            pp.isRunning = false;
            pp.isCrouching = false;
        }

        // for air movement
        else if (!pp.isGrounded && pp.direction.x!=0 )
        {
            pp.rb.AddForce(new Vector2(pp.airMoveSpeed * pp.direction.x,0));
            if (Mathf.Abs(pp.rb.velocity.x) > pp.groundedMoveSpeed)
            {
                pp.rb.velocity = new Vector2(pp.direction.x * pp.groundedMoveSpeed, pp.rb.velocity.y);
            }
        }
    }
}
