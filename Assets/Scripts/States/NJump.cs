using System.Collections;
using UnityEngine;

public class NJump : PlayerState
{
    public NJump(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerScript.jumpForce);
        PlayerScript.Animator.Play("NJUMP_START");

        yield break;
    }
}