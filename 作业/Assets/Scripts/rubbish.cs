using UnityEngine;
using System.Collections;

public class rubbish : MonoBehaviour {

	public float max = 15;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = new Vector3(Random.Range(5, max), Random.Range(0,1), Random.Range(5, max));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
