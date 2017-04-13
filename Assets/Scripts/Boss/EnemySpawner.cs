using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyToSpawn;
    public bool Spawning;
    public float SpawnDelay;
    private float SpawnCountdown;

	// Use this for initialization
	void Start ()
	{
	    SpawnCountdown = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Spawning)
	    {
	        if (SpawnCountdown >= SpawnDelay)
	        {
	            SpawnCountdown = 0f;
                var SpawnedEnemy = (GameObject)Instantiate(EnemyToSpawn[Random.Range(0, EnemyToSpawn.Length)], GetComponent<Transform>().position + new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)),
                    Quaternion.Euler(0f, 0f, 0f));
                //SpawnedEnemy.GetComponent<X>().X = X;
            }
	        else
	        {
	            SpawnCountdown += Time.deltaTime;
	        }
	    }
	}

    public void ToggleSpawning(bool shouldSpawn)
    {
        Spawning = shouldSpawn;
    }
}
