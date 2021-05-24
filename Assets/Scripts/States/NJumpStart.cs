using System.Collections;
using UnityEngine;

public class NJumpStart : State
{
    public NJumpStart(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerScript.jumpForce);
        PlayerScript.Animator.Play("NJUMP_START");

        PlayerScript.SetRecovery(false, PlayerScript.isRecovered);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
    }
}