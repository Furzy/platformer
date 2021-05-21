using System.Collections;
using UnityEngine;

public class Landing : State
{
    public Landing(PlayerScript playerScript, PlayerMovementScript playerMovementScript) : base (playerScript, playerMovementScript){}
    public override IEnumerator Start()
    {
        PlayerScript.Animator.Play("LANDING");

        // PlayerScript.isRecovered = false;
        yield return new WaitUntil(() => PlayerScript.state.ToString() == "Landing" && PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        // yield return new WaitForSeconds(PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).length);
        PlayerScript.isRecovered = true;        
    }
}