using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<Dialog> Dialogs { get; private set; }

	// Use this for initialization
	void Start ()
    {
		Dialogs = new List<Dialog>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
