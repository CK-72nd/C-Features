using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {

        public int width = 20;
        public int height = 20;
        public Vector2 spacing = new Vector2(25f, 10f);
        public Vector2 offset = new Vector2(25f, 10f);
        public GameObject[] blockPrefabs;

        private GameObject[,] spawnedBlocks;

        [Header("Debug")]
        public bool isDebugging = false;

        // Use this for initialization
        void Start()
        {
            GenerateBlocks();
        }

        void updateBlocks()
        {
            //Loop through entire 2D array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //update positions
                    GameObject currentBlock = spawnedBlocks[x, y];
                    //create a new position
                    Vector2 pos = new Vector2(x * spacing.x,
                                              y * spacing.y);
                    //add an offset to pos
                    pos += offset;
                    //set currentBlock position to a new pos
                    currentBlock.transform.position = pos;
                   
                }
            }
        }

        void GenerateBlocks()
        {
            spawnedBlocks = new GameObject[width, height];
            // Loop through the width
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Create new instance of the block
                    GameObject block = GetRandomBlock();
                    // Set the new position
                    Vector2 pos = new Vector3(x * spacing.x,
                                              y * spacing.y);
                    block.transform.position = pos;
                    //Add spawned blocks to the array
                    spawnedBlocks[x, y] = block;
                }
            }
        }

        //Function with arguments
        //<return-type> <function-name> (arguments)
        GameObject GetBlockByIndex(int index)
        {
            // Error Handling
            if (index > blockPrefabs.Length || index < 0)
                return null;

            // Create a new block at a given index
            GameObject clone = Instantiate(blockPrefabs[index]);
            // and return it
            return clone;
        }

        GameObject GetRandomBlock()
        {
            // Randomly Spawn a new GameObject
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefabs = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefabs);
            // and return it
            return clone;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDebugging)
            {
                updateBlocks();
            }
        }
    }
}