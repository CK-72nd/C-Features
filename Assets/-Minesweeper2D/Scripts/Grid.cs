using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;

        public Ray mouseRay { get; private set; }

        // Use this for initialisation
        void Start()
        {
            // Generate tiles on startup
            GenerateTiles();
        }

        void Update()
        {
            // IF Mouse Button 0 is Down
            // LET ray = Ray from Camera using Input.mousePosition
            // LET hit = Physics2D RayCast (ray.origin, ray direction)
            // IF hit's collider != null
            // LET hitTile = hit collider's Tile component
            // IF hitTile != null
            // CALL SelectTile(hitTile)
        }

        public int GetAdjacentMineCountAt(Tile t)
        {
            // Let count = 0
            int count = 0;
            // FOR x = -1 to <= 1
            // FOR y = -1 to <= 1
            // LET desiredX = t.x + x
            // LET desiredY = t.y + y
            // IF desiredX and desiredY are >= 0 AND < width/height
            // LET tile = tiles[desiredX, desiredY]
            // IF tile isMine
            // SET count = count + 1

            // RETURN Count
            return count;
        }
            public void FFuncover(int x, int y, bool[,] visited)
        {
            // IF x >= 0 AND y >= 0 AND x < width AND y < height
            // IF visited[x, y]
            // RETURN
            // LET tile = tiles[x, y]
            // LET adjacentMines = GetAdjacentMineCountAt(tile)
            // CALL tile.Reveal(adjacentMines)

            // IF adjacentMines > 0
            // RETURN

            // SET visited(x, y) = true

            // CALL FFuncover(x - 1, y, visited)
            // CALL FFuncover(x + 1, y, visited)
            // CALL FFuncover(x, y - 1, visited)
            // CALL FFuncover(x, y + 1, visited)
        }

        // Uncovers all mines that are in the grid
        public void UncoverMines(int mineState)
        {
             // FOR x = 0 to x < width
             // FOR y = 0 to y < height
             // LET currentTile = tiles[x, y]
             // IF current isMine
             // LET adjacentMines = GetAdjacentMineCountAt(currentTile)
             // CALL currentTile.Reveal(adjacentMines, mineState)
        }

        bool NoMoreEmptyTiles()
        {
            // LET emptyTileCount = 0
            int emptyTileCount = 0;
            // FOR x = 0 to x < width
            // FOR y = 0 to y < height
            // LET currentTile = tiles[x, y]
            // IF !currentTile.isRevealed AND !currentTile.isMine
            // SET emptyTileCount = emptyTileCount + 1
            // RETURN emptyTileCount
            return emptyTileCount == 0;
        }

        //Takes in a tile selected by the user in some way to reveal it
        public void SelectTile(Tile selectedTile)
        {
            // LET adjacentMines = GetAdjacentMineCountAt(selectedTile)
            // CALL selectedTile.Reveal(adjacentMines)
            // IF selectedTile isMine
            // CALL UncoverMines(0)
            // [EXTRA] Perform Game over logic
            //ELSEIF adjacentMines == 0
            // LET x = selectedTile.x
            // LET Y = selectedTile.y
            // CALL FFuncover(x, y, new bool[width, height])
            // IF NoMoreEmptyTiles()
            // CALL UncoverMines(1)
            // [EXTRA] Perform Win logic
        }

        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // position tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get Tile Component
            return currentTile; // return it
        }
        // Spawns tiles in a grid like pattern
        void GenerateTiles()
        {
            // Create new 2D array of size width x height
            tiles = new Tile[width, height];

            // Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    // Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - halfSize.x,
                                              y - halfSize.y);

                    // Apply spacing
                    pos *= spacing;
                    // Spawn the tile
                    Tile tile = SpawnTile(pos);
                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store its array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    //Store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }
       
}
}
