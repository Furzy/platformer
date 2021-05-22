using UnityEngine;
using System.Collections;

public class PlayerActionScript : MonoBehaviour {

    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField] internal PlayerScript PlayerScript;
	[SerializeField] float allowedTimeBetweenButtons = 0.3f; //tweak as needed

	private int currentIndex = 0; //moves along the array as buttons are pressed
	private float timeLastButtonPressed;
	private bool oldFacing;
    

	private string[] hcf = new string[] {"left","down","right"};
	

	// Use this for initialization
    private void Start() => PlayerScript = GetComponent<PlayerScript>();
	
	// Update is called once per frame
	private void Update () 
	{
		if(Check(hcf))
		{
			Debug.Log("HCF");
		}
	}		

	private bool Check(string[] buttons)
	{
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons && (PlayerScript.facingRight == oldFacing || PlayerScript.facingRight == !PlayerScript.facingRight)) currentIndex = 0;
		{
			if (currentIndex < buttons.Length) 
			{	
                if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1 && Input.GetKeyDown(KeyCode.DownArrow))||
                (buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == -1 && Input.GetKeyDown(KeyCode.UpArrow))||
                (buttons[currentIndex] == "neutral" && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) ||
                (buttons[currentIndex] == "left" && Input.GetAxisRaw("Horizontal") == -1 && Input.GetKeyDown(KeyCode.LeftArrow))||
                (buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1 && Input.GetKeyDown(KeyCode.RightArrow))||
                (buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "neutral" && buttons[currentIndex] != "left" && buttons[currentIndex] != "right" && Input.GetKey(buttons[currentIndex])))
                {
                    timeLastButtonPressed = Time.time;
                    oldFacing = PlayerScript.facingRight;
                    currentIndex++;
                }

                if (currentIndex >= buttons.Length)
				{
					currentIndex = 0;
					return true;
				}
				else return false;
			}
		}
		return false;
	}
}
