using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : StateMachine
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField]
    internal PlayerScript PlayerScript;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("PlayerAnimationScript Starting");
        PlayerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
