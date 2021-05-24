using System.Collections;
using UnityEngine;

public class JumpStill : State
{
    public JumpStill(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("JUMP_STILL");
        yield break;
    }
}