using System.Collections;
using UnityEngine;

public class Standing : PlayerInputState
{
    public Standing(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.SetRecovery(false);

        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("STANDING");
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        
        PlayerScript.SetRecovery(true);
    }
}