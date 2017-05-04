using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    //properties
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Cost { get; private set; }
    public int CastingTime { get; private set; }
    public string Description { get; private set; }

    //constructor
    public Skill(string name, int damage, int cost, int castingtime, string description)
    {
        this.Name = name;
        this.Damage = damage;
        this.Cost = cost;
        this.CastingTime = castingtime
        this.Description = description;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
