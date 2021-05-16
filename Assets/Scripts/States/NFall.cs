using System.Collections;
using UnityEngine;

public class NFall : State
{
    public NFall(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, PlayerMovementScript.jumpForce);
        PlayerScript.Animator.Play("NFALL");
        yield break;
    }
}