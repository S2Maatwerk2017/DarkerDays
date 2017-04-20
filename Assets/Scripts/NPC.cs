using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public List<Dialog> Dialogs;
    public Rigidbody MyRigidbody;
    public NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Start npc");
        MyRigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
