using System.Collections;
using UnityEngine;

public class Standing : State
{
    public Standing(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("STANDING");

        yield break;
        // yield return new WaitForSeconds(PlayerScript.AnimationLength);

        // PlayerScript.SetState(new Idle(PlayerScript,PlayerMovementScript));
    }
}