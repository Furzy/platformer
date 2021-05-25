using System.Collections;
using UnityEngine;

public class Standing : State
{
    public Standing(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("STANDING");

        PlayerScript.SetRecovery(false);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.SetRecovery(true);
    }

    // TODO: check this duplicate
    public static IEnumerator ExecAnimation(PlayerScript PlayerScript){
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("STANDING");

        PlayerScript.SetRecovery(false);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.SetRecovery(true);
    }
}