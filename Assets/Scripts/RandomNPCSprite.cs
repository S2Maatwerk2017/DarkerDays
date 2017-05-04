using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(270f, 0f, 0f);
    }
}
