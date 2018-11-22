using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	
	//The amount of ellapsed time
	private float time = 0;
	
	//Flags that control the state of the game
	private  bool isRunning = false;
	private  bool isFinished = false;

	//place holders for the player and the spawn point
	public  Transform spawnPoint;
	public  GameObject player;
	
	//place holders for the scripts on the character controller
	public CharacterMotor motorScript;
	public MouseLook lookScript;
	
	//This resets to game back to the way it started
	private void InitLevel()
	{
		time = 70;
		isRunning = true;
		isFinished = false;
		
		//move the player to the spawn point
		player.transform.position = spawnPoint.position;
		
		//Allow the character controller to move and
		//look around
		motorScript.enabled = true;
		motorScript.movement.maxForwardSpeed = 7;
		lookScript.enabled = true;

	}
	
	// Use this for initialization
	void Start () {
		//prevent the character controller
		//from looking around
		motorScript.enabled = false;
		lookScript.enabled = false;
		isFinished = false;
		isRunning = false;
		time = 70;
	}
	
	// Update is called once per frame
	void Update () {
		//add time to the clock if the game
		//is running
		if(isRunning)
			time -= Time.deltaTime;
		if(time <= 0 || PlayerScript.GetNumber() == 16){
			FinishGame();
		}
	}
	
	//This runs when the player enters the finish
	//zone
	public void  FinishGame()
	{
		isRunning = false;
		isFinished = true;
		
		//freeze the character controller
		motorScript.enabled = false;
		lookScript.enabled = false;
	}
	

	
	//This section creates the Graphical User Interface (GUI)
	void OnGUI()
	{
		
		if(!isRunning)
		{
			string message;
			if(isFinished)
			{
				string news;
				if(time > 0) news = "you win";
				else news = "you lose";
				GUI.Label(new Rect(Screen.width / 2 - 15, Screen.height/2 - 40, 130, 40), news);
				message = "Click to Play Again";
				if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height/2, 140, 30), message))
				{
					Application.LoadLevel(1);
				}
				if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height/2 + 50, 140, 30), "leave game"))
				{
					Application.Quit();
				}
			}
				
			else
			{
				message = "Click to Play";
				if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height/2, 140, 30), message))
				{
					//start the game if the user clicks to play
					InitLevel ();
					PlayerScript.SetNumber(0);
				}
			}
				
		}
		
		//If the game is running, show the current time
		else
		{
			GUI.Box(new Rect(0, 185, 130, 40), "Your Time Overplus");
			GUI.Label(new Rect(50, 200, 20, 30), ((int)time).ToString());
		}
		
}
}
