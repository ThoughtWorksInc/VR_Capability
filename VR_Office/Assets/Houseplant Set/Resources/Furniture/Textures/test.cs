using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public int speed = 1;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {

			gameObject.transform.RotateAround (gameObject.transform.position, new Vector3 (0, 1, 0), speed);  //  += new Vector3(0,0,speed);
	
		}
	}
}
