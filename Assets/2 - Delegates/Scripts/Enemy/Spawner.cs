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

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // Goal is to call functions randomly using delegates
        void SpawnTroll()
        {
            // Spawn troll prefab
            // SetTarget on troll to target
        }

        void SpawnOrc()
        {
            // Spawn Orc Prefab
            // SetTarget on Orc to target
        }
    }
}
