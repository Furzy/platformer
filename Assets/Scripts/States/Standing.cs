using System.Collections;
using UnityEngine;

public class Standing : State
{
    public Standing(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("STANDING");

        PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.isRecovered = true;        
    }
}