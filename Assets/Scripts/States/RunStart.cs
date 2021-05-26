using System.Collections;
using UnityEngine;

public class RunStart : PlayerState
{
    public RunStart(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerScript.runningMoveSpeed, 0f);
        PlayerScript.Animator.Play("RUN_START");
        
        PlayerScript.SetRecovery(false);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.SetRecovery(true);
    }
}