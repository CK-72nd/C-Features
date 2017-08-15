using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Weaponscript : MonoBehaviour
    {
        public float damage = 10f;
        public int maxBullets = 30;
        public float fireInterval = 0.2f;
        public GameObject bulletPrefab;
        public Transform spawnPoint;

        public Transform target;
        public bool isFired = false;
        private int currentBullets = 0;
        private Bulletscript[] spawnedBullets; // null by default
        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bulletscript[maxBullets];
        }

        // Update is called once per frame
        void Update()
        {
            //If !isFired && currentBullets < maxBullets
            if(!isFired && currentBullets < maxBullets)
            {
                //Fire!
                StartCoroutine(Fire());
            }
        }
        IEnumerator Fire()
        {
            //Run whatever is at the top of this function
            isFired = true;

            //spawn the bullet
            SpawnBullet();

            yield return new WaitForSeconds(fireInterval); // Wait for fire interval to finish

            //Run whatever is here after fireInterval
            isFired = false;

        }
        void SpawnBullet()
        {
            //1. Instantiate a bullet clone
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            //2. create direction variable for bullet and rotating
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            //3. Rotate the weapon to direction 
            transform.rotation = Quaternion.LookRotation(direction);
            //4. Grab the bullet script from clone
            Bulletscript bullet = clone.GetComponent<Bulletscript>();
            //5. Send bullet to target (by setting direction)
            bullet.direction = direction;
            //6. Store bullet in an array
            spawnedBullets[currentBullets] = bullet;
            //7. increment currentBullets
            currentBullets++;
        }

    public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}