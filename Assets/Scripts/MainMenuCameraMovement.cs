using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCameraMovement : MonoBehaviour {

	public Camera maincamera;

	// Update is called once per frame
	void FixedUpdate ()
	{
		maincamera.transform.Translate(Time.deltaTime, 0, 0);
		
	}
}
