using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;

    //For Jumping
    [Header("Jumping")]
    public float jumpForce = 0.3f;
    private bool _wantNJump;

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
        DetectJump();
    }

    private void FixedUpdate()
    {
        NJump();
    }

    private void UpdateAnim()
    {
        _wantNJump = pa.wantNJump;
    }
    private void DetectJump()
    {
        //for neutral jump
        if (pp.isGrounded && pp.direction.y == 1)
        {
            pa.wantNJump = true;
        }
    }
    private void NJump()
    {
        if (pa.wantNJump) 
        {
            pp.rb.velocity = new Vector2(pp.rb.velocity.y, jumpForce);
            pa.wantNJump = false;
        }
    }
}
