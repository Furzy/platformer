using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public PlayerInputState PlayerInputState {get; protected set;}

    public void SetPlayerInputState(PlayerInputState playerState)
    {
            PlayerInputState = playerState;
            StartCoroutine(PlayerInputState.Start());
    }
}
