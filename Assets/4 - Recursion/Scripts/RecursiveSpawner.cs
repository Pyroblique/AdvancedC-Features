using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recursion
{
    public class RecursiveSpawner : MonoBehaviour
    {
        public GameObject spawnPrefab;
        public int amount = 10;
        public float positionOffset = 1f;
        public float scaleFactor = 0.9f;

        void RecursiveSpawn(int currentAmount, Vector3 position, Vector3 scale)
        {
            amount--;

            // End case for Recursive Function
            if(amount <= 0)
            {
                return;
            }

            // Calculate offset
            Vector3 adjustedScale = scale * scaleFactor;
            Vector3 adjustedPosition = position + Vector3.up * positionOffset;

            // Instantiation spawn prefab
            GameObject clone = Instantiate(spawnPrefab);
            clone.transform.position = adjustedPosition;
            clone.transform.localScale = adjustedScale;

            // Call itself
            RecursiveSpawn(amount, adjustedPosition, adjustedScale);           
        }

        // Use this for initialization
        void Start()
        {
            Vector3 position = transform.position;
            Vector3 scale = spawnPrefab.transform.localScale;
            RecursiveSpawn(amount, position, scale);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}