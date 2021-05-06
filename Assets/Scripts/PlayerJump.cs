using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;

    public float jumpForce = 0.3f;
    public bool _wantBJump;
    public bool _wantNJump;
    public bool _wantFJump;

    // Start is called before the first frame update
    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pa = GameObject.FindObjectOfType<PlayerAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnim();
        GetJump();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void UpdateAnim()
    {
        _wantBJump = pa.wantBJump;
        _wantNJump = pa.wantNJump;
        _wantFJump = pa.wantFJump;
    }
    private void GetJump()
    {
        //for neutral jump
        if (pp.isGrounded && pp.direction.x == 0f && pp.direction.y == 1f)
        {
            pa.wantNJump = true;
        }
        //for back jump
        else if (pp.isGrounded && pp.direction.x == -1f && pp.direction.y == 1f)
        {
            pa.wantBJump = true;
        }
        //for forward jump
        else if (pp.isGrounded && pp.direction.x == 1f && pp.direction.y == 1f)
        {
            pa.wantFJump = true;
        }


    }
    private void Jump()
    {
        if (pa.wantNJump) 
        {
            pp.rb.velocity = new Vector2(0f, jumpForce);
            pa.wantNJump = false;
        }
        if (pa.wantBJump || pa.wantFJump) 
        {
            pp.rb.velocity = new Vector2(pp.direction.x, jumpForce);
            pa.wantBJump = pa.wantFJump = false;
        }
    }
}
