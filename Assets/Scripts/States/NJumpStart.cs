using System.Collections;
using UnityEngine;

public class NJumpStart : State
{
    public NJumpStart(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerMovementScript.jumpForce);
        PlayerScript.Animator.Play("NJUMP_START");

        PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        // PlayerScript.isRecovered = true;        
    }
}