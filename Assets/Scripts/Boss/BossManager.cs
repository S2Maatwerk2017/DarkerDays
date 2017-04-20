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
    public List<GameObject> Spawners;

    private int EnemiesKilled = 0;
    private bool BattleHasStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyWasKilled()
    {
        Debug.Log("Test1");
        if (BattleHasStarted)
        {
            Debug.Log("Test2");
            EnemiesKilled++;
            if (EnemiesKilled >= EnemiesToKill)
            {
                Debug.Log("Test3");
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
        Boss = Instantiate(Boss, BossSpawnLocation.position, BossSpawnLocation.rotation);
    }

    public void SpawnEnemies(bool shouldSpawn)
    {
        foreach (GameObject spawner in Spawners)
        {
            spawner.GetComponent<EnemySpawner>().ToggleSpawning(shouldSpawn);
        }
    }
}
