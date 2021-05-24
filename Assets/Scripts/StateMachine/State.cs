using System.Collections;
using UnityEngine;

public abstract class State
{
    protected PlayerScript PlayerScript;

    public State(PlayerScript playerScript)
    {
        PlayerScript = playerScript;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
