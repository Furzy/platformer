using System.Collections;
using UnityEngine;

public class FJumpStart : State
{
    public FJumpStart(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        if (PlayerScript.wantRun)
        {
          PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.runningMoveSpeed * PlayerScript.Direction.x, PlayerScript.runJumpForce);
        }
        else 
        {
          PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.walkingMoveSpeed * PlayerScript.Direction.x, PlayerScript.jumpForce);
        }
        PlayerScript.Animator.Play("FJUMP_START");

        PlayerScript.SetRecovery(false, PlayerScript.isRecovered);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
    }
}