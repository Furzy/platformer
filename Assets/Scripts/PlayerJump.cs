using UnityEngine;

public class PlayerJump : MonoBehaviour
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
        Jump();
    }

    private void Jump()
    {
        //for neutral jump
        if (pp.isGrounded && pp.direction.y == 1 && pp.direction.x == 0)
        {
            pp.isNJumping = true;
            pp.rb.velocity = new Vector2(0f, pp.jumpForce);

            pp.isWalking = false;
            pp.isRunning = false;
            pp.isCrouching = false;
        }
    }
}
