using System.Collections;
using UnityEngine;

public abstract class PlayerState
{
    public PlayerScript PlayerScript {get; protected set;}

    public PlayerState(PlayerScript playerScript)
    {
        PlayerScript = playerScript;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
