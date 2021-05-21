using System.Collections;
using UnityEngine;

public class FJumpStart : State
{
    public FJumpStart(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        if (PlayerMovementScript.wantRun)
        {
          PlayerScript.Rb2d.velocity = new Vector2(PlayerMovementScript.runningMoveSpeed * PlayerScript.Direction.x, PlayerMovementScript.runJumpForce);
        }
        else 
        {
          PlayerScript.Rb2d.velocity = new Vector2(PlayerMovementScript.walkingMoveSpeed * PlayerScript.Direction.x, PlayerMovementScript.jumpForce);
        }
        PlayerScript.Animator.Play("FJUMP_START");

        PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        // PlayerScript.isRecovered = true;        
    }
}