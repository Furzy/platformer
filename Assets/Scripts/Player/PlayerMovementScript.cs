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
    internal bool isDoubleKeying = false;
    internal bool firstKey;
    internal bool doubleKey;

    // Start is called before the first frame update
    private void Start()
    {
        print("PlayerMovementScript Starting");
        playerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckDoubleKey(KeyCode.LeftArrow);
        CheckDoubleKey(KeyCode.RightArrow);
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    private void DoMovement()
    {
        if (playerScript.isGrounded)
        {
            if (Mathf.Abs(playerScript.direction.y) < 0.1f)
            {
                if (Mathf.Abs(playerScript.direction.x) > 0.9f && !isDoubleKeying) 
                {
                    Debug.Log("Hello");
                    playerScript.rb2d.velocity = new Vector2(playerScript.direction.x * groundedMoveSpeed, 0f);
                    // playerScript.currentState = AnimationState.PLAYER_WALK;
                }
                else if (Mathf.Abs(playerScript.direction.x) > 0.9f && isDoubleKeying)
                {
                    playerScript.rb2d.velocity = new Vector2(playerScript.direction.x * runningMoveSpeed, 0f);
                    // playerScript.currentState = AnimationState.PLAYER_RUN;
                }
                else 
                {
                    playerScript.rb2d.velocity = new Vector2(0f, 0f);
                    // playerScript.currentState = AnimationState.PLAYER_IDLE;
                }
            }

            else if (playerScript.direction.y < -0.9f)
            {
                playerScript.rb2d.velocity = new Vector2(0f, 0f);
                // playerScript.currentState = AnimationState.PLAYER_CROUCHSTART;
            }

            //for jumping
            else
            {
                if (playerScript.direction.x < -0.9f) // back jumping
                {
                    // Start back jump
                    // playerScript.currentState = AnimationState.PLAYER_JUMPBACKSTART;
                }
                else if (playerScript.direction.x > 0.9f) // front jumping
                {
                    // Start front jump
                    // playerScript.currentState = AnimationState.PLAYER_JUMPFRONTSTART;
                }
                else // neutral jumping
                {
                    // Start neutral jump
                    // playerScript.currentState = AnimationState.PLAYER_JUMPNEUTRALSTART;
                }
            }
        }
    }
    private void CheckDoubleKey(KeyCode key)
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
        {isDoubleKeying = true;} 
        
        if(Input.GetKeyUp(key)) // Remove double tap on Key up
        { 
            doubleKey = false; 
            isDoubleKeying = false;
        } 

        IEnumerator WaitForSecondKey()
        { 
            firstKey = true; 
            yield return new WaitForSeconds(doubleKeySpeed); 
            firstKey = false; 
        }
    }
}
