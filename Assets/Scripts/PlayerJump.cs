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
        NJump();
    }

    private void DetectJump()
    {
        //for neutral jump
        if (pp.isGrounded && pp.direction.y == 1)
        {
            wantJump = true;
        }
    }

    private void NJump()
    {
        if (wantJump) 
        {
            pp.rb.velocity = new Vector2(pp.rb.velocity.y, pp.jumpForce);
            wantJump = false;
        }
    }
}
