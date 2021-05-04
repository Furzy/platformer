using System.Collections;
using UnityEngine;

public class PlayerDoubleTap : MonoBehaviour
{
    private PlayerProperties pp;
    private bool firstTap;
    private bool doubleTap;

    private void Start()
    {
        pp = GameObject.FindObjectOfType<PlayerProperties>();
    }
    
    private void Update()
    {
        DoubleTap(KeyCode.LeftArrow);
        DoubleTap(KeyCode.RightArrow);
    }

    private void DoubleTap(KeyCode key)
    {
        if (!firstTap) 
        { 
            if (Input.GetKeyDown(key)) 
            { 
                StartCoroutine (CheckSprint ()); 
            } 
        } 
        else 
        { 
            if (Input.GetKeyDown(key)) 
            { 
                doubleTap = true; 
            } 
        } 
        
        if (doubleTap) 
        { 
            pp.isRunning = true;
        } 
        
        if(Input.GetKeyUp(key))
        { 
            doubleTap = false; 
            pp.isRunning = false;
        } 
    }

    IEnumerator CheckSprint()
    { 
        firstTap = true; 
        yield return new WaitForSeconds(pp.doubleTapSpeed); 
        firstTap = false; 
    }

}
