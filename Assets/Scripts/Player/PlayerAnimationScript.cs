using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField]
    internal PlayerScript playerScript;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("PlayerAnimationScript Starting");
        playerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerScript.currentState)
        {
            case PlayerState.WALK:
                playerScript.animator.Play("Player_Walk");
                break;
            case PlayerState.RUN:
                playerScript.animator.Play("Player_Run");
                break;
            case PlayerState.CROUCH:
                playerScript.animator.Play("Player_CrouchStart");
                break;
            case PlayerState.NEUTRALJUMP:
                playerScript.animator.Play("Player_startNJump");
                break;
            default:
                playerScript.animator.Play("Player_Idle");
                break;
        }
    }
}
