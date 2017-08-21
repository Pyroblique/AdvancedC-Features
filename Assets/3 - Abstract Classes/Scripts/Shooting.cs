using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;

        private Weapon[] attachedWeapons;
        private Rigidbody2D rigid;

        // Happens during instantiation as well
        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Use this for initialization
        void Start()
        {
            // Get all the attachedWeapons in children
            attachedWeapons = GetComponentsInChildren<Weapon>();
            // Set the first weapon
            SwitchWeapon(weaponIndex = 0);
        }

        // Update is called once per frame
        void Update()
        {
            CheckFire();
            WeaponSwitching();
        }

        // Checks if the user pressed a button to fire the current weapon
        void CheckFire()
        {
            // Set currentWeapon to attachedWeapons[weaponIndex]
            Weapon currentWeapon = attachedWeapons[weaponIndex];
            // IF user pressed down space
            if(Input.GetKey(KeyCode.Space))
            {
                // Fire currentWeapon
                currentWeapon.Fire();
                // Add recoil to player from weapon's recoil
                rigid.AddForce(-transform.right * currentWeapon.recoil, ForceMode2D.Impulse);
            }

        }

        // Handles weapon switching when pressing keys
        void WeaponSwitching()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }
        }

        // Cycles through weapons using amount as index
        void CycleWeapon(int amount)
        {
            // SET desiredIndex to weaponIndex + amount
            int desiredIndex = weaponIndex + amount;
            // IF desiredIndex > length of weapons
            if(desiredIndex >= attachedWeapons.Length)
            {
                // SET desiredIndex to zero
                desiredIndex = 0;
            }
            // ELSE IF desired < zero
            else if(desiredIndex < 0)
            {
                // SET desiredIndex to length of weapons - 1
                desiredIndex = attachedWeapons.Length - 1;
            }
            // SET weaponIndex to desiredIndex
            weaponIndex = desiredIndex;
            // SwitchWeapon() to weaponIndex
            SwitchWeapon(weaponIndex);
        }

        // Disable all other weapons in the list and return the selected one
        Weapon SwitchWeapon(int weaponIndex)
        {
            // Check if index is outside of bounds
            if(weaponIndex < 0 || weaponIndex > attachedWeapons.Length)
            {
                // Return null as error
                return null;
            }
            // Looping through all the weapons
            for (int i = 0; i < attachedWeapons.Length; i++)
            {
                // Get the weapon at index
                Weapon w = attachedWeapons[i];
                // IF index == weaponIndex
                if(i == weaponIndex)
                {
                    // Activate the weapon
                    w.gameObject.SetActive(true);
                }
                // ELSE
                else
                {
                    // Deactivate the weapon
                    w.gameObject.SetActive(false);
                }

            }
            // Return selected weapon
            return attachedWeapons[weaponIndex];
        }
    }
}
