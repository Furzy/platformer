using System.Collections;
using UnityEngine;

public class PlayerGroundMovement : MonoBehaviour
{

    private PlayerProperties pp;
    private PlayerAnimate pa;

    public float groundedMoveSpeed = 2;
    public float runningMoveSpeed = 5;

    public float doubleTapSpeed = 0.3f;
    public bool isDoubleTapping = false;
    private bool firstTap;
    private bool doubleTap;

    // Start is called before the first frame update
    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
        pa = GameObject.FindObjectOfType<PlayerAnimate>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckDoubleTap(KeyCode.LeftArrow);
        CheckDoubleTap(KeyCode.RightArrow);
    }

    private void FixedUpdate()
    {
        DoMovement();
    }


    private void DoMovement()
    {
        if (pp.isGrounded)
        {
            // no vertical input
            if (Mathf.Abs(pp.direction.y) < 0.1f)
            {
                // for walk movement
                if (Mathf.Abs(pp.direction.x) > 0.1f && !isDoubleTapping)
                {
                    pp.rb.velocity = new Vector2(pp.direction.x * groundedMoveSpeed, 0f);
                }
                // for run movement
                else if (Mathf.Abs(pp.direction.x) > 0.1f && isDoubleTapping)
                {
                    pp.rb.velocity = new Vector2(pp.direction.x * runningMoveSpeed, 0f);
                }
                // for idle
                else if (Mathf.Abs(pp.direction.x) < 0.1f)
                {
                    pp.rb.velocity = new Vector2(0f, 0f);
                }
            }

            // for crouching
            if (pp.direction.y < -0.9f)
            {
                pp.rb.velocity = new Vector2(0f, 0f);
            }

        }
    }

    private void CheckDoubleTap(KeyCode key)
    {
        if (!firstTap) // firstTap is false by default
        { 
            if (Input.GetKeyDown(key)) 
            { 
                StartCoroutine (WaitForSecondTap());
            } 
        } 
        else // If there's already a first tap done
        { 
            if (Input.GetKeyDown(key)) 
            { 
                doubleTap = true; 
            } 
        } 
        
        if (doubleTap) 
        { 
            isDoubleTapping = true;
        } 
        
        if(Input.GetKeyUp(key)) // Remove double tap on Key up
        { 
            doubleTap = false; 
            isDoubleTapping = false;
        } 

        IEnumerator WaitForSecondTap()
        { 
            firstTap = true; 
            yield return new WaitForSeconds(doubleTapSpeed); 
            firstTap = false; 
        }
    }
}
