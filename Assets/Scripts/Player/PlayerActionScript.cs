using UnityEngine;
using System.Collections;

public class PlayerActionScript : MonoBehaviour {

    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField] internal PlayerMainScript PlayerMainScript;
    [SerializeField] internal PlayerMovementScript PlayerMovementScript;
	[SerializeField] float allowedTimeBetweenButtons = 0.3f; //tweak as needed

	private int currentIndex = 0; //moves along the array as buttons are pressed
	private float timeLastButtonPressed;
	private bool oldFacing;
    

	[SerializeField] private string[] shoryuken = new string[] {"right","down","right","space"};
	

	// Use this for initialization
    private void Start()
    {
        PlayerMainScript = GetComponent<PlayerMainScript>();
        PlayerMovementScript = GetComponent<PlayerMovementScript>();
    }
	
	// Update is called once per frame
	private void Update () 
	{
		// if(Check(shoryuken))
		// {
		// 	PlayerScript.SetPlayerInputState(new Shoryuken(PlayerScript));
        //     Debug.Log("Shoryuken");
		// }
	}		

	private bool Check(string[] buttons)
	{
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons && (PlayerMainScript.isFacingRight == oldFacing || PlayerMainScript.isFacingRight == !PlayerMainScript.isFacingRight)) currentIndex = 0;
		{
			if (currentIndex < buttons.Length) 
			{	
                if ((buttons[currentIndex] == "down" && Input.GetKeyDown(KeyCode.DownArrow)) ||
                (buttons[currentIndex] == "up" && Input.GetKeyDown(KeyCode.UpArrow)) ||
                (buttons[currentIndex] == "neutral" && !Input.anyKey) ||
                (buttons[currentIndex] == "left" && Input.GetKeyDown(KeyCode.LeftArrow)) ||
                (buttons[currentIndex] == "right" && Input.GetKeyDown(KeyCode.RightArrow)) ||
                (buttons[currentIndex] == "space" && Input.GetKeyDown(KeyCode.Space)) ||
                (buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "neutral" && buttons[currentIndex] != "left" && buttons[currentIndex] != "right" && buttons[currentIndex] != "space" && Input.GetKey(buttons[currentIndex])))
                {
                    timeLastButtonPressed = Time.time;
                    oldFacing = PlayerMainScript.isFacingRight;
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
