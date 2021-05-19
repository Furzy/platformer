using System.Collections;
using UnityEngine;

public class NFall : State
{
    public NFall(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("NFALL");

        yield break;
    }
}