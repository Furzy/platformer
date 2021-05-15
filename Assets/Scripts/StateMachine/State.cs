using System.Collections;
using UnityEngine;

public abstract class State
{
    protected PlayerScript PlayerScript;
    protected PlayerMovementScript PlayerMovementScript;

    public State(PlayerScript playerScript, PlayerMovementScript playerMovementScript)
    {
        PlayerScript = playerScript;
        PlayerMovementScript = playerMovementScript;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
