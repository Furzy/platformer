using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected PlayerState PlayerState;

    public void SetPlayerState(PlayerState playerState)
    {
            PlayerState = playerState;

            if(PlayerState.PlayerScript.isRecovered)
                StartCoroutine(PlayerState.Start());
    }
}
