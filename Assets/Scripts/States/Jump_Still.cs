using System.Collections;
using UnityEngine;

public class JumpStill : State
{
    public JumpStill(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("JUMP_STILL");
        yield break;
    }
}