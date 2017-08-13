using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Delegates
{
    public class Enemy : MonoBehaviour
    {
        public enum Behaviour
        {
            IDLE = 0,
            SEEK = 1
        }
        // Defining a delegate
        delegate void BehaviourFunc();

        public Transform target;
        public Behaviour behaviourIndex = Behaviour.SEEK;
        private List<BehaviourFunc> behaviourFuncs = new List<BehaviourFunc>();
        private NavMeshAgent agent;

        // Use this for initialization
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            // Setup our behaviours
            behaviourFuncs.Add(Idle);
            behaviourFuncs.Add(Seek);
        }

        void Idle()
        {
            // Stop the NavAgent
            agent.Stop();
        }

        void Seek()
        {
            // Resume the NavAgent
            agent.Resume();
            // IF target is not null
            agent.SetDestination(target.position);
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
            
        }

        public bool IsCloseToTarget(float distance)
        {
            // Check if target exists
            if(target != null)
            {
                float disToTarget = Vector3.Distance(transform.position, target.position);
                if(disToTarget <= distance)
                {
                    return true;
                }
            }
            return false;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            // Call current behaviour function
            behaviourFuncs[(int)behaviourIndex]();
        }
    }
}
