using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Weapon : MonoBehaviour
    {
        public int damage = 10;
        public int maxAmmo = 30;
        public float fireInterval = 0.2f;
        public bool isReady = true;

        [SerializeField]
        private int ammo = 0;

        public abstract void Fire();
        public virtual void Reload()
        {
            ammo = maxAmmo;
        }
    }
}
