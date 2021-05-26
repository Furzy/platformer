using UnityEngine;

public class PlayerStateSetter : MonoBehaviour
{
    private PlayerScript PlayerScript;

    private void Start() => PlayerScript = GetComponent<PlayerScript>();

    private void Update() => SetPlayerState();

    private void SetPlayerState()
    {
        if (PlayerScript.isRecovered)
        {
            // if (WantIdle())
            //     PlayerScript.SetPlayerInputState(new Idle(PlayerScript));
            // else if (WantWalk())
            //     PlayerScript.SetPlayerInputState(new Walk(PlayerScript));
            if (WantCrouch())
                PlayerScript.Animator.Play("CROUCH_START");
            // else if (WantNFall())
            //     PlayerScript.SetState(new NFall(PlayerScript));
            // else if (WantFJump())
            //     PlayerScript.SetState(new FJumpStart(PlayerScript));
            // else if (WantNJump())
            //     PlayerScript.SetState(new NJumpStart(PlayerScript));
            // else if (WantJumpStill())
            //     PlayerScript.SetState(new JumpStill(PlayerScript));
        }
        if (WantStanding())
            PlayerScript.Animator.Play("STANDING");


    }

    private bool WantIdle() => PlayerScript.isGrounded
                                    && Mathf.Abs(PlayerScript.Direction.x) < 0.1f
                                    && Mathf.Abs(PlayerScript.Direction.y) < 0.1f
                                    && !Input.anyKey;

    private bool WantWalk() => PlayerScript.isGrounded
                                    && Mathf.Abs(PlayerScript.Direction.x) > 0.9f
                                    && Mathf.Abs(PlayerScript.Direction.y) < 0.1f;

    private bool WantCrouch() => PlayerScript.isGrounded 
                                    && Input.GetKeyDown(KeyCode.DownArrow);

    private bool WantStanding() => PlayerScript.isGrounded
                                    && Input.GetKeyUp(KeyCode.DownArrow);

    private bool WantNJump() => PlayerScript.isGrounded
                                    && (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
                                    && Input.GetKey(KeyCode.UpArrow);

    private bool WantFJump() => PlayerScript.isGrounded
                                    && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                                    && Input.GetKey(KeyCode.UpArrow);

    private bool WantJumpStill() => !PlayerScript.isGrounded
                                    && Mathf.Abs(PlayerScript.Rb2d.velocity.y) < 0.1f;

    private bool WantNFall() => !PlayerScript.isGrounded
                                    && PlayerScript.Rb2d.velocity.y < -0.1f;

}



