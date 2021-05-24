using System.Collections;
using UnityEngine;


public class Crouching : State
{
    public Crouching(PlayerScript playerScript) : base (playerScript){}

    private IEnumerator OnEnter(){
            PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
            PlayerScript.Animator.Play("CROUCH_START");

            PlayerScript.SetRecovery(false, PlayerScript.isRecovered);
            yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
            PlayerScript.SetRecovery(true, PlayerScript.isRecovered);
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