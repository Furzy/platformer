using System.Collections;
using UnityEngine;

public class Crouching : State
{
    public Crouching(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("CROUCHING");

        yield break;
    }
}