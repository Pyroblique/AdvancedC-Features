using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Troll : Enemy
    {
        public float attackRange = 2f;
        public float meleeSpeed = 20f;
        public float meleeDelay = 0.3f;
        public GameObject attackBox;

        private bool isAttacking = false;

        // Update is called once per frame
        protected override void Update()
        {
            // Call super's update
            base.Update();
            // IF not attacking AND target is within attackRange
            if (!isAttacking && IsCloseToTarget(attackRange))
            {
                // Start Attck Coroutine
                StartCoroutine(Attack());
            }
        }

        IEnumerator Attack()
        {
            // Enemy is attacking, the attackbox is enabled
            // AND the behaviour is currently idle
            isAttacking = true;
            attackBox.SetActive(true);
            behaviourIndex = Behaviour.IDLE;
            yield return new WaitForSeconds(meleeDelay);
            behaviourIndex = Behaviour.SEEK;
            attackBox.SetActive(false);
            isAttacking = false;
        }
    }
}

