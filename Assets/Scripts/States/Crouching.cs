using System.Collections;
using UnityEngine;


public class Crouching : State
{
    public Crouching(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}

    private IEnumerator OnEnter(){
            PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
            PlayerScript.Animator.Play("CROUCH_START");

            PlayerScript.isRecovered = false;
            yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
            PlayerScript.isRecovered = true;  
    }
    
    private IEnumerator OnMain(){
            PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
            PlayerScript.Animator.Play("CROUCHING");
            yield break;
    }

    public override IEnumerator Start()
    {
        yield return OnEnter();
        yield return OnMain();       
    }
}