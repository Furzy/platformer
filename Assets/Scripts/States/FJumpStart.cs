using System.Collections;
using UnityEngine;

public class FJumpStart : PlayerInputState
{
    public FJumpStart(PlayerScript playerScript) : base (playerScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.walkingMoveSpeed * PlayerScript.Direction.x, PlayerScript.jumpForce);
        PlayerScript.Animator.Play("FJUMP_START");

        PlayerScript.SetRecovery(false);
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
    }
}