using System.Collections;
using UnityEngine;

public class Shoryuken : State
{
    public Shoryuken(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("SHORYUKEN");

        PlayerScript.SetRecovery(false, PlayerScript.isRecovered);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.37f);
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerScript.jumpForce);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.SetRecovery(true, PlayerScript.isRecovered);
    }
}