using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

    public class Boss : Enemy, IStrategy
    {
        public List<GameObject> Spawners;
        public GameObject BossManager;

        public override void Setup()
        {
            BossManager = GameObject.Find("BossManager");
            base.Setup();
        }

        public override void DoBehavior()
        {
            if (BossManager.GetComponent<BossManager>().BossMayAggro)
            {

            }
            else
            {
                SpawnEnemies();
            }
        }

        public override void StandardAI()
        {
            DoBehavior();
        }

        private void SpawnEnemies()
        {
            foreach (GameObject spawner in Spawners)
            {
                //spawner.GetComponent<SpawnerScript>().Spawn();
            }
        }

        public override void Attack()
        {
            
        }

    }

