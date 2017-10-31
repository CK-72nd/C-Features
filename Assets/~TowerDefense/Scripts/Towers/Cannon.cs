using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : MonoBehaviour
    {
        public Transform barrel; // Reference to barrel where bullet will be shot from
        public GameObject projectilePrefab; // Prefab of projectile to instantiate when firing
        
        void Fire(Enemy targetEnemy)
        {
            // LET targetPos = targetEnemy position
            
            // LET targetPos = barrel's position

            // LET barrelRot = barrel's rotation

            // LET fireDirection = targetPos - barrelPos

            // SET cannon's rotation = Quaternion.LookRotation(fireDirection, Vector3.up)

            // LET clone = Instantiate(projectilePrefab, barrelPos, barrelRot)
            
            // LET p = clone's Projectile component
            
            // SET p.direction = fireDirection 
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}