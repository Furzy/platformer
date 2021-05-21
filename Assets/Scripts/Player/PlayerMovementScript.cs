using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField]
    internal PlayerScript PlayerScript;

    [Header("Movement")]
    [SerializeField] internal Vector2 Velocity;
    [SerializeField] internal float groundedMoveSpeed = 2;
    [SerializeField] internal float runningMoveSpeed = 5;
    [SerializeField] internal float doubleKeySpeed = 0.3f;

    [Header("Jumping")]
    [SerializeField] internal float jumpForce = 2;

    internal bool firstKey;
    internal bool doubleKey;
    [SerializeField] internal bool wantRun = false;

    // Start is called before the first frame update
    private void Start() => PlayerScript = GetComponent<PlayerScript>();

    private void Update() {
        CheckRun(KeyCode.LeftArrow);
        CheckRun(KeyCode.RightArrow);
        SetState();

        Velocity = PlayerScript.Rb2d.velocity;
    }

    private void SetState()
    {
        // WALK
        if (PlayerScript.isGrounded 
            && Mathf.Abs(PlayerScript.Direction.x) > 0.9f
            && Mathf.Abs(PlayerScript.Direction.y) < 0.1f
            && !wantRun)
        {
            PlayerScript.SetState(new Walk(PlayerScript, this));
        }
        // RUN_START
        else if (PlayerScript.isGrounded 
            && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            && (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
            && wantRun)
        {
            PlayerScript.SetState(new RunStart(PlayerScript, this));
        }
        // CROUCH_START
        else if (PlayerScript.isGrounded 
            && Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerScript.SetState(new CrouchStart(PlayerScript, this));
        }
        // STANDING
        else if (PlayerScript.isGrounded 
            && Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayerScript.SetState(new Standing(PlayerScript, this));
        }
        // NFALL
        else if (!PlayerScript.isGrounded
            && PlayerScript.Rb2d.velocity.y < -0.1f)
        {
            PlayerScript.SetState(new NFall(PlayerScript, this));
        }
        // LANDING
        else if (PlayerScript.isGrounded 
            && PlayerScript.state.ToString() == "NFall")
        {
            PlayerScript.SetState(new Landing(PlayerScript, this));
        }

        else if (PlayerScript.isRecovered)
        {
            // IDLE
            if (PlayerScript.isGrounded 
                && Mathf.Abs(PlayerScript.Direction.x) < 0.1f
                && Mathf.Abs(PlayerScript.Direction.y) < 0.1f)
            {
                PlayerScript.SetState(new Idle(PlayerScript, this));
            }
            // NJUMP_START
            else if (PlayerScript.isGrounded 
                && (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
                && Input.GetKey(KeyCode.UpArrow))
            {
                PlayerScript.SetState(new NJumpStart(PlayerScript, this));
            }
            // CROUCHING
            else if (PlayerScript.isGrounded 
                && Input.GetKey(KeyCode.DownArrow) 
                && !Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayerScript.SetState(new Crouching(PlayerScript, this));
            }
            // RUN
            else if (PlayerScript.isGrounded 
                && (!Input.GetKeyDown(KeyCode.LeftArrow) || !Input.GetKeyDown(KeyCode.RightArrow))
                && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                && wantRun)
            {
                PlayerScript.SetState(new Run(PlayerScript, this));
            }
            // JUMP_STILL
            else if (!PlayerScript.isGrounded
                && Mathf.Abs(PlayerScript.Rb2d.velocity.y) < 0.1f)
            {
                PlayerScript.SetState(new JumpStill(PlayerScript, this));
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



