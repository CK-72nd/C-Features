using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force; // total force calculated from behaviours
        public Vector3 velocity; // direction of travel and speed
        public float maxVelocity = 100f; // max amount of velocity
        public float maxDistance = 10f; // max amount of velocity
        public bool freezeRotation = false; // do we want to freeze the rotation?

        private NavMeshAgent nav;
        // list of SteeringBehaviours (i.e, Seek, Flee, Wander, etc)
        private List<SteeringBehaviours> behaviours;


        void Awake()
        {
            nav.GetComponent<NavMeshAgent>();
        }

        // Use this for initialization
        void Start()
        {
            behaviours = new List<SteeringBehaviours>(GetComponents<SteeringBehaviours>());
        }

        void ComputeForces()
        {
            // SET force Vector3.zero
            force = Vector3.zero;
            // FOR i := 0 < behaviours.Count
            for (int i = 0; i < behaviours.Count; i++)
            {   
                // LET behaviour = behaviours[i]
                SteeringBehaviours behaviour = behaviours[i];
                // IF behaviour.isActiveAndEnabled == false
                if (behaviour.isActiveAndEnabled == false)
                {
                    // continue
                    continue;
                }
                // SET force = force + behaviour.GetForce() * behaviour.weighting
                force = force + behaviour.GetForce() * behaviour.weight;
                // IF force > maxVelocity
                if (force.magnitude > maxVelocity)
                {
                    // SET force = force.normalized * maxVelocity
                    force = force.normalized * maxVelocity;
                    // break
                    break;
                }
            }          
        }

        void ApplyVelocity()
        {
            // SET velocity = velocity + force * deltaTime
            velocity = velocity + force * Time.deltaTime;
            // IF velocity.magnitude > maxVelocity
                // SET velocity = velocity.normalized * maxVelocity
            // IF velocity.magnitude > 0
                // SET transform.position = transform.position + velocity * deltaTime
                // SET transform.rotation = Quaternion LookRotation (velocity)
        }


        // Update is called once per frame
        void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}
