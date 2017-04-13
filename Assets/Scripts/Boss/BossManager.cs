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
    private bool BattleHasStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyWasKilled()
    {
        if (BattleHasStarted)
        {
            EnemiesKilled++;
            if (EnemiesKilled >= EnemiesToKill)
            {
                Boss.GetComponent<Boss>().BossMayAggro = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !BattleHasStarted)
        {
            CloseGate();
            StartFight();
            BattleHasStarted = true;
        }
    }

    private void CloseGate()
    {
        Gate.GetComponent<Gate>().CloseGate();
    }

    public void OpenGate()
    {
        Gate.GetComponent<Gate>().OpenGate();
    }

    private void StartFight()
    {
        Instantiate(Boss, BossSpawnLocation.position, BossSpawnLocation.rotation);
    }
}
