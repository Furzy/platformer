using System.Collections;
using UnityEngine;

public class Run : State
{
    public Run(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(PlayerScript.Direction.x * PlayerMovementScript.runningMoveSpeed, 0f);
        PlayerScript.Animator.Play("RUN");
        
        yield break;
    }
}
