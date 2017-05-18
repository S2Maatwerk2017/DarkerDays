using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //properties
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int Cost { get; private set; }
    public int CastingTime { get; private set; }
    public float Delay { get; private set; }
    public string Description { get; private set; }

    //constructor
    public Skill(int id, string name, int damage, int cost, int castingtime, float delay, string description)
    {
        this.ID = id;
        this.Name = name;
        this.Damage = damage;
        this.Cost = cost;
        this.CastingTime = castingtime;
        this.Delay = delay;
        this.Description = description;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
