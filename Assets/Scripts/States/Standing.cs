using UnityEngine;

public class STANDING : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        PlayerMainScript.SetRecovery(false);
        animator.Play("STANDING");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("STANDING") && stateInfo.normalizedTime > 1f)
        {
            PlayerMainScript.SetRecovery(true);
            animator.Play("IDLE");
        }

    }
}
