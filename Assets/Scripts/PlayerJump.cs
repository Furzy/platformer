using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;
    private PlayerGroundMovement pgm;

    public float jumpForce = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pa = GameObject.FindObjectOfType<PlayerAnimate>();
        pgm = GameObject.FindObjectOfType<PlayerGroundMovement>();
    }

    private void FixedUpdate()
    {
        DoJump();
    }


    private void DoJump()
    {
        if (pp.direction.y > 0.9f)
        {
            if (pp.isGrounded)
            {
                // Neutral Jump
                if (Mathf.Abs(pp.direction.x) < 0.1f)
                {
                    pp.rb.velocity = new Vector2(0f, jumpForce);
                }
                // Forward Jump
                else if (Mathf.Abs(pp.direction.x) > 0.1f)
                {
                    pp.rb.velocity = new Vector2(pp.direction.x * pgm.groundedMoveSpeed * 0.6f, jumpForce);
                }
            }
        }
    }
}
