using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerMainScript PlayerMainScript;

    private void Start() => PlayerMainScript = GetComponent<PlayerMainScript>();

    private void Update() => SetPlayerMovement();

    private void SetPlayerMovement()
    {
        if (PlayerMainScript.isRecovered)
        {
            if (WantCrouch()) 
                DoCrouch();
            else if (WantStanding())
                DoStanding();
            else if (WantWalk())
                DoWalk();
            else if (WantNJump())
                DoNJump();
            else if (WantFJump())
                DoFJump();
            else if (WantJumpStill())
                DoJumpStill();
            else if (WantNFall())
                DoNFall();
            else if (WantFFall())
                DoFFall();
        }
    }

    private bool WantCrouch() => PlayerMainScript.isGrounded 
                                    && Input.GetKeyDown(KeyCode.DownArrow);
    private void DoCrouch()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerMainScript.Animator.Play("CROUCH");
    }

    private bool WantStanding() => PlayerMainScript.isGrounded
                                    && (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.DownArrow));
    private void DoStanding()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerMainScript.Animator.Play("STANDING");
    }

    private bool WantWalk() => PlayerMainScript.isGrounded
                                    && Mathf.Abs(PlayerMainScript.Direction.x) > 0.9f
                                    && Mathf.Abs(PlayerMainScript.Direction.y) < 0.1f
                                    && !Input.GetKey(KeyCode.UpArrow);
    private void DoWalk()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(PlayerMainScript.Direction.x * PlayerMainScript.walkingMoveSpeed, 0f);
        PlayerMainScript.Animator.Play("WALK");

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            DoIdle();
    }

    private bool WantIdle() => PlayerMainScript.isGrounded
                                    && Mathf.Abs(PlayerMainScript.Direction.x) < 0.1f
                                    && Mathf.Abs(PlayerMainScript.Direction.y) < 0.1f
                                    && !Input.anyKey;
    private void DoIdle()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerMainScript.Animator.Play("IDLE");
    }

    private bool WantNJump() => PlayerMainScript.isGrounded
                                    && (!Input.GetKey(KeyCode.LeftArrow) | !Input.GetKey(KeyCode.RightArrow))
                                    && Input.GetKeyDown(KeyCode.UpArrow);

    private void DoNJump()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(PlayerMainScript.walkingMoveSpeed * PlayerMainScript.Direction.x, PlayerMainScript.jumpForce);
        PlayerMainScript.Animator.Play("NJUMP");
    }

    private bool WantJumpStill() => !PlayerMainScript.isGrounded
                                    && Mathf.Abs(PlayerMainScript.Rb2d.velocity.y) < 0.1f;
    private void DoJumpStill() => PlayerMainScript.Animator.Play("JUMP_STILL");
    
    private bool WantNFall() => !PlayerMainScript.isGrounded
                                    && PlayerMainScript.Rb2d.velocity.y < -0.1f
                                    && Mathf.Abs(PlayerMainScript.Rb2d.velocity.x) < 0.1f;
    private void DoNFall() => PlayerMainScript.Animator.Play("NFALL");

    private bool WantFFall() => !PlayerMainScript.isGrounded
                                    && PlayerMainScript.Rb2d.velocity.y < -0.1f
                                    && Mathf.Abs(PlayerMainScript.Rb2d.velocity.x) > 0.9f;
    private void DoFFall() => PlayerMainScript.Animator.Play("NFALL");

    private bool WantFJump() => PlayerMainScript.isGrounded
                                    && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                                    && Input.GetKey(KeyCode.UpArrow);
    private void DoFJump()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(PlayerMainScript.walkingMoveSpeed * PlayerMainScript.Direction.x, PlayerMainScript.jumpForce);
        PlayerMainScript.Animator.Play("FJUMP");
    }



}



