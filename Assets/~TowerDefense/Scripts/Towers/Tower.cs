using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public Cannon cannon; // Reference to cannon inside of tower
        public float attackRate = 0.25f; // Rate of attack in seconds
        public float attackRadius = 5f; // Distance of attack in world units
        private float attackTimer = 0f; // Timer to count up to attackRate
        private List<Enemy> enemies = new List<Enemy>(); // List of enemy within radius


        void OnTriggerEnter(Collider col)
        {
            // LET e = col's Enemy component
            // IF e != null
                // Add e to enemies list
        }

        void OnTriggerExit(Collider col)
        {
           // LET e = col's Enemy component
           // IF e != null
                // Remove e from enemies list 
        }

        Enemy GetClosestEnemy()
        {
            // LET closest = null
            Enemy closest = null;
            // LET minDistance = float.MaxValue
            // FOREACH enemy in enemies
            // LET distance = the distance between transform's position and enemy's position)
            // IF distance < minDistance
            // SET minDistance = distance
            // SET closest = enemy
            // RETURN closest
            return closest; 
        }

        void Attack()
        {
            // LET closest to GetClosestEnemy()
            // IF closest != null
                // CALL cannon.Fire() and pass closest as argument
        }

        void Update()
        {
            // SET attackTimer = attackTimer + deltaTime
            // IF attackTimer >= attackRate
                // CALL Attack()
                // SET attackTimer = 0
        }

    }
}