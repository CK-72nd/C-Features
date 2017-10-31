using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Seek : SteeringBehaviours
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            // LET force = Vector3.zero
            Vector3 force = Vector3.zero;
            // If target == null
            if (target == null)
            {
                // return force
                return force;
            }
        
            // LET desiredForce = target position - transform position
            
            // IF desiredForce.magnitude > stoppingDistance
            // SET desiredForce = desiredForce.normalized * weighting
            // SET force = desiredForce - owner.velocity

            
            // Return the Force luke!
            return force;
        }


    }
}
