using UnityEngine;
using System.Collections;

public class testcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.UpArrow)) 
		{									//x,y,z

			float speed = 1 * Time.deltaTime;
			transform.position += new Vector3 (0, 0, speed);
			Debug.Log ("Pressed.");
		}
			
	}
}
