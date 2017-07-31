using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Health : MonoBehaviour
    {
        public int health = 100;

        // Update is called once per frame
        void Update()
        {
            // IF health <= 0
            if(health <=0)
            {
                // Destroy the gameObject
                Destroy(gameObject);
            } 
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
