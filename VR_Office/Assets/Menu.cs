using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		OVRTouchpad.Create ();
		OVRTouchpad.TouchHandler += HandleTouchHandler;
	}

	void HandleTouchHandler (object sender, System.EventArgs e)
	{
		OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
		if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
		{
			SceneManager.LoadScene ("officenewest");
		//	OVRTouchpad.TouchHandler.EndInvoke ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
