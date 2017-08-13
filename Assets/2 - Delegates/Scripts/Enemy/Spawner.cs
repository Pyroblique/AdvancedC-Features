using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Spawner : MonoBehaviour
    {
        public Transform target;
        public GameObject orcPrefab;
        public GameObject trollPrefab;
        public float minAmount = 0, maxAmount = 20;
        public float spawnRate = 1f;
        delegate GameObject ClosestFunc(Vector3 position);
        ClosestFunc findClosest;

        void Start()
        {
            SpawnOrc();
        }

        // Goal is to call functions randomly using delegates
        void SpawnTroll()
        {
            // Spawn troll prefab
            // SetTarget on troll to target
        }

        void SpawnOrc()
        {
            // Spawn troll prefab
            StartCoroutine(OrcSpawn());
            // SetTarget on troll to target
            
        }

        // Spawn Orc Prefab
        IEnumerator OrcSpawn()
        {
            yield return new WaitForSeconds(1); 
            Instantiate(orcPrefab, transform.position, transform.rotation);
                    
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
        // SetTarget on Orc to target
        GameObject FindClosestPlayer(Vector3 position)
        {
            PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();
            float minDistance = float.MaxValue;
            GameObject closest = null;
            for (int i = 0; i < players.Length; i++)
            {
                Vector3 playerPos = players[i].transform.position;
                float distance = Vector3.Distance(playerPos, position);
                if (distance <= minDistance)
                {
                    distance = minDistance;
                    closest = players[i].gameObject;
                }
            }
            return closest;
        }
    }
}
