using System.Collections;
using UnityEngine;


public class Crouch : State
{
    public Crouch(PlayerScript playerScript) : base (playerScript){}


    private void OnStartup(){
            PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
            PlayerScript.Animator.Play("CROUCH_START");
    }
    
    private void OnActive(){
            PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
            PlayerScript.Animator.Play("CROUCHING");
    }

    public override IEnumerator Start()
    {
        PlayerScript.SetRecovery(false);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            OnStartup();

        yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        
        if (!Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKey(KeyCode.DownArrow))
            OnActive();      
             
        PlayerScript.SetRecovery(true);
    }
}