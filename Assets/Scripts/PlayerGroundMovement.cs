using System.Collections;
using UnityEngine;

public class PlayerGroundMovement : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;

    public Vector2 velocity;
    public float groundedMoveSpeed;
    public float runningMoveSpeed;

    public float doubleTapSpeed = 0.3f;
    private bool firstTap;
    private bool doubleTap;

    public bool _wantCrouch;
    public bool _wantWalk;
    public bool _wantRun;

    // Start is called before the first frame update
    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pa = GameObject.FindObjectOfType<PlayerAnimate>();
    }

    // Update is called once per frame
    private void Update()
    {
        velocity = pp.rb.velocity;
        UpdateAnim();

        DoubleTap(KeyCode.LeftArrow);
        DoubleTap(KeyCode.RightArrow);

        GetMovement();
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    private void UpdateAnim()
    {
        _wantCrouch = pa.wantCrouch;
        _wantRun = pa.wantRun;
        _wantWalk = pa.wantWalk;
    }

    private void GetMovement()
    {
        if (pp.isGrounded)
        {
            //for crouching
            if (pp.direction.y == -1f)
            {
                //for animation
                pa.wantCrouch = true;
                pa.wantRun = false;
                pa.wantWalk = false;                
            }
            //for idle
            else if (pp.direction.x == 0f && pp.direction.y == 0f)
            {
                //for animation
                pa.wantCrouch = false;
                pa.wantRun = false;
                pa.wantWalk = false;
            }
            //for walk movement
            else if (pp.direction.x!=0f && pa.wantRun == false)
            {
                //for animation
                pa.wantCrouch = false;
                pa.wantRun = false;
                pa.wantWalk = true;
            }
            //for run movement
            else if (pp.direction.y == 0f && pp.direction.x!= 0f && pa.wantRun == true)
            {
                //for animation
                pa.wantCrouch = false;
                pa.wantRun = true;
                pa.wantWalk = false;
            }
        }
    }

    private void DoMovement()
    {
        if (pp.isGrounded)
        {
            //for crouching
            if (pa.wantCrouch)
            {
                //stopping horizontal velocity
                pp.rb.velocity = new Vector2(0f, pp.rb.velocity.y);
            }
            //for idle
            if (pp.direction.x == 0f && pp.direction.y == 0f)
            {
                //for animation
                pa.wantCrouch = false;
                pa.wantRun = false;
                pa.wantWalk = false;

                //stopping horizontal velocity
                pp.rb.velocity = new Vector2(0f, pp.rb.velocity.y);
            }
            //for walk movement
            if (pp.direction.x != 0f && pa.wantRun == false)
            {
                //for animation
                pa.wantCrouch = false;
                pa.wantRun = false;
                pa.wantWalk = true;

                pp.rb.velocity = new Vector2(pp.direction.x * groundedMoveSpeed, pp.rb.velocity.y);
            }
            //for run movement
            if (pp.direction.y == 0f && pp.direction.x!= 0f && pa.wantRun == true)
            {
                //for animation
                pa.wantCrouch = false;
                pa.wantRun = true;
                pa.wantWalk = false;

                pp.rb.velocity = new Vector2(pp.direction.x * runningMoveSpeed, pp.rb.velocity.y);
            }
        }
    }


    private void DoubleTap(KeyCode key)
    {
        if (!firstTap) 
        { 
            if (Input.GetKeyDown(key)) 
            { 
                StartCoroutine (CheckDoubleTap()); 
            } 
        } 
        else 
        { 
            if (Input.GetKeyDown(key)) 
            { 
                doubleTap = true; 
            } 
        } 
        
        if (doubleTap) 
        { 
            pa.wantRun = true;
        } 
        
        if(Input.GetKeyUp(key))
        { 
            doubleTap = false; 
            pa.wantRun = false;
        } 

        IEnumerator CheckDoubleTap()
        { 
            firstTap = true; 
            yield return new WaitForSeconds(doubleTapSpeed); 
            firstTap = false; 
        }
    }


}
