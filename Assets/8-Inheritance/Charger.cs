using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 10f;
        public GameObject dashParticles;

        protected override void Attack()
        {
            // Perform an OverlapSphere
            // Start timer
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }
    }
}
