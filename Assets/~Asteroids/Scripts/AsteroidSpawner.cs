using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] asteroidsPrefabs;
        public float spawnRate = 1f;
        public float spawnRadius = 5f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("Spawn", 0f, spawnRate);
        }

        
        void Spawn()
        {
            //Generate randomized position
            Vector3 rand = Random.insideUnitSphere * spawnRadius;
            rand.z = 0f;
            Vector3 position = transform.position + rand;
            int randIndex = Random.Range(0, asteroidsPrefabs.Length);
            GameObject randAsteroid = asteroidsPrefabs[randIndex];
            GameObject clone = Instantiate(randAsteroid);
            clone.transform.position = position;
        }
    }
}
