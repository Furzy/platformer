using System.Collections;
using UnityEngine;

public class Idle : State
{
    public Idle(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("IDLE");
        yield break;
    }
}
