using System.Collections;
using UnityEngine;

public class CrouchStart : State
{
    public CrouchStart(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("CROUCH_START");
        yield break;

        // yield return new WaitForSeconds(PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).length);
        // PlayerScript.isRecovered = true;
        
        // yield return new Crouching(PlayerScript, PlayerMovementScript);
    }
}