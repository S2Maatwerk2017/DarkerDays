using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyToSpawn;
    public bool Spawning;
    public float SpawnDelay;
    private float SpawnCountdown;
    private List<GameObject> BossEnemies;

	// Use this for initialization
	void Start ()
	{
	    SpawnCountdown = 0f;
        BossEnemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Spawning)
	    {
	        if (SpawnCountdown >= SpawnDelay)
	        {
	            SpawnCountdown = 0f;
                BossEnemies.Add((GameObject)Instantiate(EnemyToSpawn[Random.Range(0, EnemyToSpawn.Length)], GetComponent<Transform>().position + new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)),
                    Quaternion.Euler(0f, 0f, 0f)));
            }
	        else
	        {
	            SpawnCountdown += Time.deltaTime;
	        }
	    }
	    else
	    {
	        foreach (var item in BossEnemies)
	        {
	            Destroy(item);
	        }
	    }
	}

    public void ToggleSpawning(bool shouldSpawn)
    {
        Spawning = shouldSpawn;
    }
}
