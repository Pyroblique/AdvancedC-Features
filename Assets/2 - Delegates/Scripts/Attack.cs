using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Attack : MonoBehaviour
    {
        public int damage = 10;

        protected virtual void OnTriggerEnter(Collider other)
        {
            // IF an object with health component attached has been hit
            Health health = other.GetComponent<Health>();
            if(health != null)
            {
                // Inflict damage on object
                health.TakeDamage(damage);
            }
        }
    }
}
