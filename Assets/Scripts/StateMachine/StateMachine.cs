using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected PlayerScript PlayerScript;
    protected State State;

    public void SetState(State state)
    {
            State = state;
            StartCoroutine(State.Start());
    }
}
