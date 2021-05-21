using System.Collections;
using UnityEngine;

public class RunStart : State
{
    public RunStart(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerMovementScript.runningMoveSpeed, 0f);
        PlayerScript.Animator.Play("RUN_START");
        
        PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.isRecovered = true;        
    }
}