using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions
{

    public class Shooting : MonoBehaviour
    {
        public GameObject spawnPointPrefab;

        public GameObject projectilePrefab;
        // Speed at which the projectile will be firing
        public float projectileSpeed = 10f;
        // kickback from you projectile
        public float recoil = 30;
        // Rate of fire
        public float fireRate = 0.1f;
        // Timer to count up to shootRate
        private float shootTimer = 0f;
        // container for Rigidbody2D
        private Rigidbody2D rigid;
     
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }


        // Update is called once per frame
        void Update()
        {
            // Increase timer
            shootTimer += Time.deltaTime;
            // if spacebar is pressed and shootTimer >= fireRate
            if (Input.GetKey(KeyCode.Space) && shootTimer>= fireRate)
            {
                // CALL Shoot()
                Shoot();
                //Reset shootTimer = 0
                shootTimer = 0;
            }
        }

        void Shoot()
        {
            // Instantiate gameObject here
            GameObject projectile = Instantiate(projectilePrefab);
            // Position of projectile to player's position
            projectile.transform.position = spawnPointPrefab.transform.position;
            // get projectile rigidbody
            Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
            projectileRigid.AddForce(transform.up * projectileSpeed);
            // apply recoil
            rigid.AddForce(-transform.up * recoil, ForceMode2D.Impulse);
        }

    }

}