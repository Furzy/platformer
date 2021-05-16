using System.Collections;
using UnityEngine;

public class NJump : State
{
    public NJump(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerMovementScript.jumpForce);
        PlayerScript.Animator.Play("NJUMP_START");
        yield break;
    }
}