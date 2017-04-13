using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float timeToDestroy = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeToDestroy -= Time.deltaTime;

	    if (timeToDestroy <= 0)
	    {
	        Destroy(gameObject);
	    }
	}
}
