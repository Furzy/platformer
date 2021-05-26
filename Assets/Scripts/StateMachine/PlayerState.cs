using System.Collections;
using UnityEngine;

public abstract class PlayerInputState
{
    public PlayerScript PlayerScript {get; protected set;}

    public PlayerInputState(PlayerScript playerScript)
    {
        PlayerScript = playerScript;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
