using System.Collections;
using UnityEngine;

public class JumpStill : PlayerState
{
    public JumpStill(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("JUMP_STILL");
        yield break;
    }
}