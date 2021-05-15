using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : StateMachine
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField]
    internal PlayerScript PlayerScript;

    [Header("Movement")]
    [SerializeField] internal float groundedMoveSpeed = 2;
    [SerializeField] internal float runningMoveSpeed = 5;
    [SerializeField] internal float doubleKeySpeed = 0.3f;

    internal bool firstKey;
    internal bool doubleKey;
    [SerializeField] internal bool wantRun = false;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("PlayerMovementScript Starting");
        PlayerScript = GetComponent<PlayerScript>();
    }

    private void Update() {
        CheckMovement();
        CheckRun(KeyCode.LeftArrow);
        CheckRun(KeyCode.RightArrow);
    }

    private void CheckMovement()
    {
        if (PlayerScript.isGrounded)
        {
            if (Mathf.Abs(PlayerScript.Direction.y) < 0.1f)
            {
                if (Mathf.Abs(PlayerScript.Direction.x) > 0.9f)
                {
                    if (!wantRun)
                    {
                        PlayerScript.SetState(new Walk(PlayerScript, this));   
                    }
                    else
                    {
                        PlayerScript.SetState(new Run(PlayerScript, this));
                    }
                }
                else 
                {
                    PlayerScript.SetState(new Idle(PlayerScript, this));
                }
            }

            else if (PlayerScript.Direction.y < -0.9f)
            {
                    // PlayerScript.ChangeState(PlayerState.CROUCH);
            }

            //for jumping
            else
            {
                if (PlayerScript.Direction.x < -0.9f) 
                {
                    // PlayerScript.ChangeState(PlayerState.BACKJUMP);
                }
                else if (PlayerScript.Direction.x > 0.9f) 
                {
                    // PlayerScript.ChangeState(PlayerState.FORWARDJUMP);
                }
                else // neutral jumping
                {
                    // PlayerScript.ChangeState(PlayerState.NEUTRALJUMP);
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
}



