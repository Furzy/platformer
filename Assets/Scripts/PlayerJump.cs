using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;

    private bool wantJump = false;

    // Start is called before the first frame update
    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pa = GameObject.FindObjectOfType<PlayerAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectJump();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void DetectJump()
    {
        //for neutral jump
        if (pp.isGrounded && pp.direction.y == 1 && pp.direction.x == 0)
        {
            wantJump = true;
            pp.isNJumping = true;

            pp.isWalking = false;
            pp.isRunning = false;
            pp.isCrouching = false;
        }
    }

    private void Jump()
    {
        if (wantJump) 
        {
            pp.rb.AddForce(Vector2.up * pp.jumpForce, ForceMode2D.Impulse);
            wantJump = false;
        }
    }
}
