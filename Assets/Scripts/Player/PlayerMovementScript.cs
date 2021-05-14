using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField]
    internal PlayerScript playerScript;

    [Header("Movement")]
    [SerializeField]
    internal float groundedMoveSpeed = 2;
    [SerializeField]
    internal float runningMoveSpeed = 5;
    [SerializeField]
    internal float doubleKeySpeed = 0.3f;

    internal bool firstKey;
    internal bool doubleKey;
    internal bool wantRun = false;


    

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("PlayerMovementScript Starting");
        playerScript = GetComponent<PlayerScript>();
    }

    private void Update() {
        CheckMovement();
        CheckRun(KeyCode.LeftArrow);
        CheckRun(KeyCode.RightArrow);
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    private void CheckMovement()
    {
        if (playerScript.isGrounded)
        {
            if (Mathf.Abs(playerScript.direction.y) < 0.1f)
            {
                if (Mathf.Abs(playerScript.direction.x) > 0.9f)
                {
                    playerScript.ChangeState(PlayerState.WALK);

                    if (wantRun) 
                    {
                        playerScript.ChangeState(PlayerState.RUN);
                    }
                }
                else 
                {
                    playerScript.ChangeState(PlayerState.IDLE);
                }
            }

            else if (playerScript.direction.y < -0.9f)
            {
                    playerScript.ChangeState(PlayerState.CROUCH);
            }

            //for jumping
            else
            {
                if (playerScript.direction.x < -0.9f) 
                {
                    playerScript.ChangeState(PlayerState.BACKJUMP);
                }
                else if (playerScript.direction.x > 0.9f) 
                {
                    playerScript.ChangeState(PlayerState.FORWARDJUMP);
                }
                else // neutral jumping
                {
                    playerScript.ChangeState(PlayerState.NEUTRALJUMP);
                }
            }
        }
    }

    private void CheckRun(KeyCode key)
    {
        if (!firstKey) // firstTap is false by default
        { 
            if (Input.GetKeyDown(key)) 
            {StartCoroutine (WaitForSecondKey());} 
        } 
        else // If there's already a first tap done
        { 
            if (Input.GetKeyDown(key)) 
            {doubleKey = true;} 
        } 
        
        if (doubleKey) 
        {wantRun = true;} 
        
        if(Input.GetKeyUp(key)) // Remove double tap on Key up
        { 
            doubleKey = false; 
            wantRun = false;
        } 

        IEnumerator WaitForSecondKey()
        { 
            firstKey = true; 
            yield return new WaitForSeconds(doubleKeySpeed); 
            firstKey = false; 
        }
    }

    private void DoMovement()
    {
        switch (playerScript.currentState)
        {
            case PlayerState.WALK:
                playerScript.rb2d.velocity = new Vector2(playerScript.direction.x * groundedMoveSpeed, 0f);
                break;
            case PlayerState.RUN:
                playerScript.rb2d.velocity = new Vector2(playerScript.direction.x * runningMoveSpeed, 0f);
                break;
            default:
                playerScript.rb2d.velocity = new Vector2(0f, 0f);
                break;
        }
    }
}



