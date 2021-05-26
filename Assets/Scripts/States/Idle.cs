using System.Collections;
using UnityEngine;

public class Idle : PlayerState
{
    public Idle(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("IDLE");

        yield break;
    }
}
