using System.Collections;
using UnityEngine;

public class Walk : State
{
    public Walk(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerMovementScript.groundedMoveSpeed, 0f);
        PlayerScript.Animator.Play("WALK");
        yield break;
    }
}
