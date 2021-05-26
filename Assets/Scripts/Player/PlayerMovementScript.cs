using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerMainScript PlayerMainScript;

    private void Start() => PlayerMainScript = GetComponent<PlayerMainScript>();

    private void Update() => SetPlayerMovement();

    private void SetPlayerMovement()
    {
        if (WantCrouch()) 
            DoCrouch();
        else if (WantStanding())
            DoStanding();
        else if (WantWalk())
            DoWalk();
    }

    private bool WantCrouch() => PlayerMainScript.isGrounded 
                                    && Input.GetKeyDown(KeyCode.DownArrow);
    private void DoCrouch()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerMainScript.Animator.Play("CROUCH");
    }

    private bool WantStanding() => PlayerMainScript.isGrounded
                                    && Input.GetKeyUp(KeyCode.DownArrow);
    private void DoStanding()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerMainScript.Animator.Play("STANDING");

    }

    private bool WantWalk() => PlayerMainScript.isGrounded
                                    && Mathf.Abs(PlayerMainScript.Direction.x) > 0.9f
                                    && Mathf.Abs(PlayerMainScript.Direction.y) < 0.1f;
    private void DoWalk()
    {
        PlayerMainScript.Rb2d.velocity = new Vector2(PlayerMainScript.Direction.x * PlayerMainScript.walkingMoveSpeed, 0f);
        PlayerMainScript.Animator.Play("WALK");

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerMainScript.Rb2d.velocity = new Vector2(0f, 0f);
            PlayerMainScript.Animator.Play("IDLE");
        }
    }

    private bool WantIdle() => PlayerMainScript.isGrounded
                                    && Mathf.Abs(PlayerMainScript.Direction.x) < 0.1f
                                    && Mathf.Abs(PlayerMainScript.Direction.y) < 0.1f
                                    && !Input.anyKey;




    private bool WantNJump() => PlayerMainScript.isGrounded
                                    && (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
                                    && Input.GetKey(KeyCode.UpArrow);

    private bool WantFJump() => PlayerMainScript.isGrounded
                                    && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                                    && Input.GetKey(KeyCode.UpArrow);

    private bool WantJumpStill() => !PlayerMainScript.isGrounded
                                    && Mathf.Abs(PlayerMainScript.Rb2d.velocity.y) < 0.1f;

    private bool WantNFall() => !PlayerMainScript.isGrounded
                                    && PlayerMainScript.Rb2d.velocity.y < -0.1f;

}



