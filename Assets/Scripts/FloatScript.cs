using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {
    Vector3 startPos;
    float delta = 1f;
    float speed = 2f;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = startPos;
        v.y += Mathf.Abs(delta * Mathf.Sin(Time.time * speed));
        transform.position = v;
    }
}
