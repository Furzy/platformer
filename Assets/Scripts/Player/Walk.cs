using System.Collections;
using UnityEngine;

public class Walk : State
{
    public Walk(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerScript.groundedMoveSpeed, 0f);
        PlayerScript.Animator.Play("Player_Walk");
        yield break;
    }
}
