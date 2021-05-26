using System.Collections;
using UnityEngine;

public class Walk : PlayerState
{
    public Walk(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerScript.walkingMoveSpeed, 0f);
        PlayerScript.Animator.Play("WALK");
        yield break;
    }
}
