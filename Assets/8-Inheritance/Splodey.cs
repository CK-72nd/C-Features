using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float explosionRadius = 10f;
        public float impactForce = 10f;
        public GameObject explosionParticles;
        public float explosionRate = 1f;

        public float explosionTimer = 0f;

        protected override void Attack()
        {
            // If explosionTimer reaches rate
            if (explosionTimer >= explosionRate)
            {
                // Call explode
                splode();
            }
        }

        protected override void OnAttackEnd()
        {
            // Reset Explosion Timer
            explosionTimer = 0f;
        }

        // Use this for initialization
        void Start()
        {

        }

        protected override void Update()
        {
            base.Update();
            // Start Explosion Timer
            explosionTimer += Time.deltaTime;
        }

        public void splode()
        {
            // Physics.OverLapSphere()
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
            // For Each hit in hits
            foreach (Collider hit in hits)
            {
                Health h = hit.GetComponent<Health>();
                // If hit player
                if (h != null)
                {
                    // decrease health from player
                    h.TakeDamage(damage);
                    // add force to player's rigid
                    rigid.AddExplosionForce(impactForce, transform.position, explosionRadius);
                }
            }
        }

    }
}
