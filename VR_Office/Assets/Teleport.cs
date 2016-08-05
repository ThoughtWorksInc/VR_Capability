using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject playerController;
	int activeCam;
	Vector3[] cams;
	Quaternion[] rots;

	// Use this for initialization
	void Start () {
		float ypos = -0.72f;

		cams = new Vector3[5];

		cams[0] = new Vector3 (-0.26f, ypos, 5.6f);
		cams[1] = new Vector3 (-2.85f, ypos,-25.2f);
		cams[2] = new Vector3 (-3.61f, ypos,13.7f);
		cams[3] = new Vector3 (13.75f, ypos,13.7f);
		cams[4] = new Vector3 (3.5f, ypos, 24.4f);

		rots = new Quaternion[5];

		rots [0] = new Quaternion();
		rots [1] = new Quaternion();
		rots [2] = new Quaternion();
		rots [3] = new Quaternion();
		rots [4] = new Quaternion();



		rots[0] = Quaternion.Euler(new Vector3 (0, 147, 0));
		rots[1] = Quaternion.Euler(new Vector3 (0, 0, 0));
		rots[2] = Quaternion.Euler(new Vector3 (0, 176, 0));
		rots[3] = Quaternion.Euler(new Vector3 (0, 242, 0));
		rots[4] = Quaternion.Euler(new Vector3 (0, 320, 0));

		OVRTouchpad.Create ();
		OVRTouchpad.TouchHandler += HandleTouchHandler;

	}

	void HandleTouchHandler (object sender, System.EventArgs e)
	{
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
		if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
		{
			SwitchCam();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SwitchCam(){

		int lastcam = cams.Length - 1;

		if (activeCam == lastcam) {
			activeCam = 0;
		} 
		else {
			activeCam++;
		}

		playerController.transform.position = cams[activeCam];
		playerController.transform.rotation = rots [activeCam];

	}
}
