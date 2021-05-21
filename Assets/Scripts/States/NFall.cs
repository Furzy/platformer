using System.Collections;
using UnityEngine;

public class NFall : State
{
    public NFall(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("NFALL");

        // PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => Mathf.Abs(PlayerScript.Rb2d.velocity.y) < 0.1f);
        // PlayerScript.isRecovered = true;        
    }
}