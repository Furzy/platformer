using System.Collections;
using UnityEngine;

public class Crouch : State
{
    public Crouch(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("CROUCH_START");
        yield break;
    }
}