﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = 0.2f;

        public float shootTimer = 0f;

        //Shoots a bullet
        void Shoot()
        {
            //Create a new bullet
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //Grab rigidbody2D from bullet clone
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
            //Add force using bullet speed
            rigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            //Count up shootTimer with deltaTime
            shootTimer = Time.deltaTime;
            //If shootTimer > shootRate
            if(shootTimer > shootRate)
            {
                //If space is pressed
                if(Input.GetKey(KeyCode.Space))
                {
                    //Shoot bullet!
                    Shoot();
                    //Reset shootTimer
                    shootTimer = 0f;
                }
            }
            
        }
    }
}
