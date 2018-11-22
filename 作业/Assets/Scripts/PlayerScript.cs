using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public static int number = 0;
	private CharacterMotor chMotor;

	// Use this for initialization
	void Start () {
		number = 0;
		chMotor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void SetNumber(int n)
	{
		number = n;
	}

	public static int GetNumber()
	{
		return number;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "rubbish"){
			Destroy (other.gameObject);
			number++;
			chMotor.movement.maxForwardSpeed ++;
		}
	}

	void OnGUI(){
		GUI.Box(new Rect(0, Screen.height - 115, 130, 40), "Your Rubbish Is");
		GUI.Label(new Rect(55, Screen.height - 100, 20, 30), ((int)number).ToString());
	}
}
