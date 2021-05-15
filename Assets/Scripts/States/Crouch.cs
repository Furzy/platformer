using System.Collections;
using UnityEngine;

public class Crouch : State
{
    public Crouch(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {

        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);

        var name = PlayerScript.state.GetName();
        if (name.ToString() != "CROUCH_START")
        {
            PlayerScript.Animator.Play("CROUCH_START");
        }
        else
        {
            PlayerScript.Animator.Play("CROUCHING");
        }
        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
    }    
}