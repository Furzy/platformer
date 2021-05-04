using UnityEngine;
using System.Collections;

public class PlayerActionScript : MonoBehaviour {

	private int currentIndex = 0; //moves along the array as buttons are pressed
	private float timeLastButtonPressed;
	private bool oldFacing;
	private PlayerProperties pp;
    
	[SerializeField] float allowedTimeBetweenButtons = 0.3f; //tweak as needed
	[SerializeField] float moveTimer = 0.0f;
	// [SerializeField] bool recovered = true;

	private string[] hcf = new string[] {"left","down","right"};
	

	// Use this for initialization
	private void Start () 
	{
		pp = GameObject.FindObjectOfType<PlayerProperties>();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if(Check(hcf))
		{
			// do hcf
		}
	}		

	private bool Check(string[] buttons)
	{
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons && (pp.facingRight == oldFacing || pp.facingRight == !pp.facingRight)) currentIndex = 0;
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
						oldFacing = pp.facingRight;
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

	// public IEnumerator Recover(float waitTime) 
	// {
	// 	recovered = false;
	// 	yield return new WaitForSeconds(waitTime);
	// 	recovered = true;
	// 	moveTimer = 0;
	// }

	public void startRunning()
	{
		if(moveTimer==0)
		{
			// START MOVE

			// moveTimer = Time.time+1.0f;
			// StartCoroutine(Recover(0f));
		}else if(Time.time > moveTimer)
		{
			moveTimer = 0;	
		}
	}

}
