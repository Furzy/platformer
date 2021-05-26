using System.Collections;
using UnityEngine;


public class Crouch : PlayerInputState
{
    public Crouch(PlayerScript playerScript) : base (playerScript){}

    public override IEnumerator Start()
    {
        PlayerScript.SetRecovery(false);

        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("CROUCH_START");
        if (PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).IsName("CROUCH"))
            yield return new WaitUntil(() => PlayerScript.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f);
        else
            yield return new WaitUntil(() => !Input.GetKey(KeyCode.DownArrow));

        PlayerScript.Rb2d.velocity = new Vector2(0f, 0f);
        PlayerScript.Animator.Play("CROUCHING");
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.DownArrow));

        // Debug.Log(PlayerScript.PlayerInputState);
        // if (PlayerScript.PlayerInputState.ToString() != "Standing")
        //     PlayerScript.SetPlayerInputState(new Standing(PlayerScript));
    }
}