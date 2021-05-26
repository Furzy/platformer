using System.Collections;
using UnityEngine;

public class Run : PlayerState
{
    public Run(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerScript.runningMoveSpeed, 0f);
        PlayerScript.Animator.Play("RUN");
        
        yield break;
    }
}
