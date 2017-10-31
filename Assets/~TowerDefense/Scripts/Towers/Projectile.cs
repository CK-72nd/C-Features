using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Projectile : MonoBehaviour
    {
        public float damage = 50f; // Damage dealt to whatever gets hit
        public float speed = 50f; // Speed the projectile travels
        public Vector3 direction; // Direction the projectile travels

        public Rigidbody rb;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // LET velocity = direction.normalized x speed
            rb.velocity = direction.normalized * speed;
            // SET projectile's position += velocity x deltaTime
            transform.position += rb.velocity * Time.deltaTime;
        }

        void OnTriggerEnter(Collider col)
        {
            // LET e = col's Enemy component
            Enemy e = col.GetComponent<Enemy>();

            // IF e != null
            if (e != null)
            {
                // CALL e.DealDamage
                e.DealDamage(damage);
                // Destroy gameObject
                Destroy(gameObject);
            }
            // IF col's name == "Ground"
            if(col.gameObject.name == "Ground")
            {
                // Destroy the projectile
                Destroy(gameObject);
            }

        }

    }
}
