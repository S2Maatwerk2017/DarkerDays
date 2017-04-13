using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossManager : MonoBehaviour {


    public bool BossMayAggro;
    public int EnemiesToKill;
    public GameObject Boss;
    public Transform BossSpawnLocation;
    public GameObject Gate;

    private int EnemiesKilled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyWasKilled()
    {
        EnemiesKilled++;
        if (EnemiesKilled >= EnemiesToKill)
        {
            BossMayAggro = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CloseGate();
            StartFight();
        }
    }

    private void CloseGate()
    {
        Gate.GetComponent<Gate>().CloseGate();
    }

    private void StartFight()
    {
        Instantiate(Boss, BossSpawnLocation);
    }
}
