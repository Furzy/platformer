using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Animator anim;
    private PlayerProperties pp;
    private SpriteRenderer sp;

    public bool facingRight = true;

    [HideInInspector]
    public bool isDoubleTapping = false;



    // Start is called before the first frame update
    private void Start()
    {
		anim = GetComponent<Animator>();
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        sp = GetComponent<SpriteRenderer>();  
    }

    private void Update()
    {
        Animate();
        Flip();
    }

    private void Animate()
	{
        anim.SetFloat("DirectionXAbs", Mathf.Abs(pp.direction.x));
        anim.SetFloat("DirectionY", pp.direction.y);
        anim.SetFloat("DirectionYAbs", Mathf.Abs(pp.direction.y));
        anim.SetFloat("VelocityX", pp.rb.velocity.x);
        anim.SetFloat("VelocityY", pp.rb.velocity.y);
        anim.SetBool("isGrounded", pp.isGrounded);
        anim.SetBool("isDoubleTapping", isDoubleTapping);
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


