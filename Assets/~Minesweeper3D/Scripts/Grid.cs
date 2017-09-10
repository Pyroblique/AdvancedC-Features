using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    public class Grid : MonoBehaviour
    {
        public GameObject blockPrefab;
        // The grid's dimensions
        public int width = 10;
        public int height = 10;
        public int depth = 10;
        public float spacing = 1.2f; // How much spacing between each Block

        // Multi-Dimensional Array storing the blocks (in this case 3D)
        private Block[,,] blocks;

        // Spawns a block at position and returns the block component
        Block SpawnBlock(Vector3 pos)
        {
            GameObject clone = Instantiate(blockPrefab); // Instantiate clone
            clone.transform.position = pos; // Set position
            Block currentBlock = clone.GetComponent<Block>(); // Get Block component
            return currentBlock; // Return it
        }

        // Spawns blocks in a grid-like fashion
        void GenerateBlocks()
        {
            // Create 3D array to store all the blocks
            blocks = new Block[width, height, depth];

            // Loop through the X, Y and Z axis of the 3D array
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    for(int z = 0; z < depth; z++)
                    {
                        // Calculate half size using array dimensions
                        Vector3 halfSize = new Vector3(width / 2, height / 2, depth / 2);
                        // Make sure to offset by half (so that elements are centered)
                        halfSize -= new Vector3(0.5f, 0.5f, 0.5f);
                        // Create position for element to pivot Grid zero
                        Vector3 pos = new Vector3(x - halfSize.x, y - halfSize.y, z - halfSize.z);
                        // Apply spacing 
                        pos *= spacing;
                        // Spawn the block at that position
                        Block block = SpawnBlock(pos);
                        // Attach block to grid as a child
                        block.transform.SetParent(transform);
                        // Store array coordinate inside the block itself
                        block.x = x;
                        block.y = y;
                        block.z = z;
                        // Store block in the array at coordinates
                        blocks[x, y, z] = block;
                    }
                }
            }
        }
          
        // Count adjacent mines at element
        int GetAdjacentMineCountAt(Block b)
        {
            int count = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for(int z = -1; z <= 1; z++)
                    {
                        // Calculate adjacent element's index
                        int desiredX = b.x + x;
                        int desiredY = b.y + y;
                        int desiredZ = b.z + z;

                        // Coordinates in range?
                        if(desiredX >= 0 && desiredY >= 0 && desiredZ >= 0 && desiredX < width && desiredY < height && desiredZ < depth)
                        {
                            // Then check for mine
                            Block currentBlock = blocks[desiredX, desiredY, desiredZ];
                            if(currentBlock.isMine)
                            {
                                // Increment the count
                                count++;
                            }
                        }
                    }
                }
                
            }
            // Return the total recorded at the end of the algorithm
            return count;
        }

        void FFuncover(int x, int y, int z, bool[,,] visited)
        {
            if(x >= 0 && y >= 0 && z >= 0 && x < width && y < height && z <depth)
            {
                // Visited already?
                if (visited[x, y, z])
                    return;

                // Uncover element
                Block block = blocks[x, y, z];
                int adjacentMines = GetAdjacentMineCountAt(block);
                block.Reveal(adjacentMines);

                // Close to a mine
                if (adjacentMines > 0)
                    return; // Then no more work is needed here

                // Set visited flag
                visited[x, y, z] = true;

                // Perform recursion in each axis to detect adjacent elements
                FFuncover(x - 1, y, z - 1, visited);
                FFuncover(z + 1, y, z - 1, visited);
                FFuncover(x, y - 1, z - 1, visited);
                FFuncover(x, y + 1, z - 1, visited);

                FFuncover(x - 1, y, z, visited);
                FFuncover(z + 1, y, z, visited);
                FFuncover(x, y - 1, z, visited);
                FFuncover(x, y + 1, z, visited);

                FFuncover(x - 1, y, z - 1, visited);
                FFuncover(z + 1, y, z - 1, visited);
                FFuncover(x, y - 1, z - 1, visited);
                FFuncover(x, y + 1, z - 1, visited);
                FFuncover(x, y, z + 1, visited);
            }
        }

        // Uncovers all mines that are in the grid
        public void UncoverMines()
        {
            // Loop throughout all elements in array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        // Get currentBlock at index
                        // IF currentBlock is a mine
                        
                        // Reveal the mine
                    }

                }
            }
        }

        // Takes in a block selected by the user in some way to reveal it
        public void SelectBlock(Block selectedBlock)
        {
            // Reveal the selected block

            // IF the selected block is a mine
                // Uncover all other mines
            // ELSE IF there are no adjacent mines
                // Perform Flood Fill algorithm to reveal all empty blocks
        }

        // Use this for initialization
        void Start()
        {
            // Generate blocks on startup 
            GenerateBlocks();
        }

        // Update is called once per frame
        void Update()
        {
            // IF left mouse button is up
                // IF raycast out from camera hits something
                    // Get hit object's block component
                    // CALL SelectBlock() and pass in the hit block
        }
    }
}