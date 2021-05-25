using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField]
    internal PlayerScript PlayerScript;

    // Start is called before the first frame update
    private void Start() => PlayerScript = GetComponent<PlayerScript>();

    private void Update() {
        SetState();
    }

    private void SetState()
    {
        if (PlayerScript.isRecovered)
        {
            if (WantWalk())
                PlayerScript.SetState(new Walk(PlayerScript));
            else if (WantCrouch())
                PlayerScript.SetState(new Crouching(PlayerScript));
            else if (WantStand())
                PlayerScript.SetState(new Standing(PlayerScript));
            else if (WantNFall())
                PlayerScript.SetState(new NFall(PlayerScript));
            else if (WantIdle())
                PlayerScript.SetState(new Idle(PlayerScript));
            else if (WantFJump())
                PlayerScript.SetState(new FJumpStart(PlayerScript));
            else if (WantNJump())
                PlayerScript.SetState(new NJumpStart(PlayerScript));
            else if (WantJumpStill())
                PlayerScript.SetState(new JumpStill(PlayerScript));
        }
        // // RUN_START
        // else if (PlayerScript.isGrounded
        //     && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        //     && (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
        //     /*&& wantRun*/)
        // {
        //     PlayerScript.SetState(new RunStart(PlayerScript));
        // }
        // // LANDING
        // else if (PlayerScript.isGrounded)
        // {
        //     PlayerScript.SetState(new Landing(PlayerScript));
        // }

        // // CROUCHING
        // else if (PlayerScript.isGrounded
        //     && Input.GetKey(KeyCode.DownArrow)
        //     && !Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     PlayerScript.SetState(new Crouching(PlayerScript));
        // }
        // RUN
        // else if (PlayerScript.isGrounded
        //     && (!Input.GetKeyDown(KeyCode.LeftArrow) || !Input.GetKeyDown(KeyCode.RightArrow))
        //     && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        //     /*&& wantRun*/)
        // {
        //     PlayerScript.SetState(new Run(PlayerScript));
        // }
    }

    private bool WantJumpStill()
    {
        return !PlayerScript.isGrounded
                    && Mathf.Abs(PlayerScript.Rb2d.velocity.y) < 0.1f;
    }

    private bool WantNJump()
    {
        return PlayerScript.isGrounded
                    && (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
                    && Input.GetKey(KeyCode.UpArrow);
    }

    private bool WantFJump()
    {
        return PlayerScript.isGrounded
                    && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                    && Input.GetKey(KeyCode.UpArrow);
    }

    private bool WantIdle()
    {
        return PlayerScript.isGrounded
                    && Mathf.Abs(PlayerScript.Direction.x) < 0.1f
                    && Mathf.Abs(PlayerScript.Direction.y) < 0.1f;
    }

    private bool WantNFall()
    {
        return !PlayerScript.isGrounded
                    && PlayerScript.Rb2d.velocity.y < -0.1f;
    }

    private bool WantStand()
    {
        return PlayerScript.isGrounded
                    && Input.GetKeyUp(KeyCode.DownArrow);
    }

    private bool WantWalk()
    {
        return PlayerScript.isGrounded
                    && Mathf.Abs(PlayerScript.Direction.x) > 0.9f
                    && Mathf.Abs(PlayerScript.Direction.y) < 0.1f
                    /*&& !wantRun*/;
    }
    private bool WantCrouch()
    {
        return PlayerScript.isGrounded
                    && Input.GetKeyDown(KeyCode.DownArrow);
    }
}



