using System.Collections;
using UnityEngine;

public class Landing : PlayerState
{
    public Landing(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("LANDING");

        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.SetRecovery(true);
    }
}