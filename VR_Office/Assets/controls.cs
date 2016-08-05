using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public Camera cam4;
	public Camera cam5;

	public int activeCam = 0;


	public Camera [] cams;
	// Use this for initialization
	void Start () {
		cams = new Camera[5];
		cams [0] = cam1;
		cams [1] = cam2;
		cams [2] = cam3;
		cams [3] = cam4;
		cams [4] = cam5;

		foreach (Camera c in cams) {
			c.enabled = false;
		}
		cams[activeCam].enabled = true;

		OVRTouchpad.Create ();
		OVRTouchpad.TouchHandler += HandleTouchHandler;

	}

	void HandleTouchHandler (object sender, System.EventArgs e)
	{
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
		if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
		{
			//TODO: Insert code here to handle a single tap.  Note that there are other TouchTypes you can check for like directional swipes, but double tap is not currently implemented I believe.
			SwitchCam();
		}
	}

	void SwitchCam(){

		int lastcam = cams.Length - 1;

		cams [activeCam].enabled = false;

		if (activeCam == lastcam) {
			activeCam = 0;
		} 
		else {
			activeCam++;
		}

		cams [activeCam].enabled = true;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
		//	Debug.Log ("KRessed");
			SwitchCam();

		}
	}
}
