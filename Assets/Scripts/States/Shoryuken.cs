using System.Collections;
using UnityEngine;

public class Shoryuken : State
{
    public Shoryuken(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("SHORYUKEN");

        PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.37f);
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerMovementScript.jumpForce);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        PlayerScript.isRecovered = true;        
    }
}