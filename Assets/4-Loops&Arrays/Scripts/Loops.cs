
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{
    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefabs;
        public float frequency = 5;
        public float amplitude = 6;
        public int spawnAmount = 10;
        public float spawnRadius = 5f;
        public string message = "Print This";
        private float printTime = 2f;

        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            /*
             * while (condition)
             {
               // statement
             }
            */
            // Infinite loop
            SpawnObjectsWithSine();

        }

        // Update is called once per frame
        void Update()
        {
            //Count up timer in seconds
          
            //Loop through until timer gets to print time
            while (timer <= printTime)
            {
                timer += Time.deltaTime;
                print("PUT THE COOKIE DOWN!");
            }
        }

        void SpawnObjects()
        {
            /*
             for (initialisation; condition; iteration)
             {
                // Statement(s)
             }
            */
        }

        void SpawnObjectsWithSine()
        {
            /*
             for (initialisation; condition; iteration)
             {
                // Statement(s)
             }
            */
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                // Store randomly selected prefab
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                // Instantiate randomly selected prefab
                GameObject clone = Instantiate(randomPrefab);
                // Grab the MeshRenderer
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                // Change the color 
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b, a);
                // Generated random position within circle (sphere actually)
                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                // Set spawned object's position
                clone.transform.position = randomPos;
                // cancel out the Z
                randomPos.z = 0;
            }
        }
    }
}