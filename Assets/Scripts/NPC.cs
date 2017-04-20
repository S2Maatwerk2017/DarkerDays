using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public List<Dialog> Dialogs { get; private set; }
    public Rigidbody MyRigidbody;
    public NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
		Dialogs = new List<Dialog>();
        MyRigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
