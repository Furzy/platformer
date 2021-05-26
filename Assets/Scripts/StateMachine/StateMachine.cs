using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public StateMachineBehaviour StateMachineBehaviour {get; protected set;}
    public PlayerScript PlayerScript {get; protected set;}

    public void SetPlayerInputState(StateMachineBehaviour stateMachineBehaviour, PlayerScript playerScript)
    {
            StateMachineBehaviour = stateMachineBehaviour;
            PlayerScript = playerScript;
            PlayerScript.Animator.Play("CROUCH_START");
            
            // StartCoroutine(StateMachineBehaviour.Start());
    }
}
