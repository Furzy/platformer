using UnityEngine;

public class PlayerStateSetter : MonoBehaviour
{
    private PlayerScript PlayerScript;

    private void Start() => PlayerScript = GetComponent<PlayerScript>();

    private void Update() => SetCurrentState();

    private void SetCurrentState()
    {
        if (PlayerScript.isRecovered)
        {
            if (WantIdle())
                PlayerScript.SetState(new Idle(PlayerScript));
            else if (WantWalk())
                PlayerScript.SetState(new Walk(PlayerScript));
            else if (WantCrouch())
                PlayerScript.SetState(new Crouch(PlayerScript));
            // else if (WantStand())
            //     PlayerScript.SetState(new Standing(PlayerScript));
            // else if (WantNFall())
            //     PlayerScript.SetState(new NFall(PlayerScript));
            // else if (WantFJump())
            //     PlayerScript.SetState(new FJumpStart(PlayerScript));
            // else if (WantNJump())
            //     PlayerScript.SetState(new NJumpStart(PlayerScript));
            // else if (WantJumpStill())
            //     PlayerScript.SetState(new JumpStill(PlayerScript));
        }
    }

    private bool WantIdle() => PlayerScript.isGrounded
                                    && Mathf.Abs(PlayerScript.Direction.x) < 0.1f
                                    && Mathf.Abs(PlayerScript.Direction.y) < 0.1f;

    private bool WantWalk() => PlayerScript.isGrounded
                                    && Mathf.Abs(PlayerScript.Direction.x) > 0.9f
                                    && Mathf.Abs(PlayerScript.Direction.y) < 0.1f;

    private bool WantCrouch() => PlayerScript.isGrounded
                                    && PlayerScript.Direction.y < 0.9f;

    private bool WantStand() => PlayerScript.isGrounded
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



