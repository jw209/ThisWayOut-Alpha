using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    // map dimensions
    private const int gridWidth = 22;
    private const int gridHeight = 30;

    // things the script needs to know about
    public GameObject[] obstacles;
    public TileBase[] tbLayer;

    void Awake()
    {
        // get components
        Grid grid = gameObject.GetComponent<Grid>();
        Tilemap tilemap = gameObject.GetComponent<Tilemap>();
        TilemapRenderer renderer = gameObject.GetComponent<TilemapRenderer>();

        // set sorting
        renderer.sortingOrder = 0;

        // generate ground tiles
        for (int x = -1; x < gridWidth+2; x++)
        {
            //if (x < 0 || x > gridWidth && Random.Range(0, 100) < 20)
            //    continue;

            for (int y = -1; y < gridHeight+2; y++)
            {
                //if (y < 0 || y > gridHeight && Random.Range(0, 100) < 20)
                //    continue;
                if (x < 0 || x > gridWidth)
                {
                    if (y % 2 == 0)
                        continue;
                }

                if (y < 0 || y > gridHeight)
                {
                    if (x % 2 == 0)
                        continue;
                }

                tilemap.SetTile(new Vector3Int(x, y, 0), tbLayer[0]);
            }
        }

        Vector3[,] treePositions = new Vector3[4, 12];
        // populate possible positions for trees
        for (int quadrant = 0; quadrant < 4; quadrant++)
        {
            int i = 0;
            switch (quadrant)
            {
                // bottom left corner of map
                case 0:
                    for (int x = 1; x < 9; x += 4)
                    {
                        for (int y = 1; y < 10; y += 4)
                        {
                            treePositions[quadrant, i] = new Vector3(x, y, 0);

                            i++;
                        }
                    }
                    break;
                // bottom right corner of map
                case 1:
                    for (int x = 13; x < 21; x += 4)
                    {
                        for (int y = 1; y < 10; y += 4)
                        {
                            treePositions[quadrant, i] = new Vector3(x, y, 0);

                            i++;
                        }
                    }
                    break;
                // top left corner of map
                case 2:
                    for (int x = 1; x < 9; x += 4)
                    {
                        for (int y = 18; y < 29; y += 4)
                        {
                            treePositions[quadrant, i] = new Vector3(x, y, 0);

                            i++;
                        }
                    }
                    break;
                // top right corner of map
                case 3:
                    for (int x = 13; x < 21; x += 4)
                    {
                        for (int y = 18; y < 29; y += 4)
                        {
                            treePositions[quadrant, i] = new Vector3(x, y, 0);

                            i++;
                        }
                    }
                    break;
            } 
        }

/*
        for (int q = 0; q < 4; q++)
        {
            for (int x = 0; x < 12; x++)
            {
                Debug.Log(treePositions[q,x]);
            }
        }
*/

        int numTrees = 24;
        Vector3[] occupiedPositions = new Vector3[numTrees];
        // generate trees
        for (int i = 0; i < numTrees; i++)
        {
            int quadrant = Random.Range(0, 4);
            int tree = Random.Range(0, 12);

            occupiedPositions[i] = treePositions[quadrant, tree];

            GameObject obj = Instantiate(obstacles[0], this.gameObject.transform.position + treePositions[quadrant, tree], Quaternion.identity);
            obj.transform.parent = this.gameObject.transform;
        }

        // generate dirt
        int roadDensity = 300;
        for (int i = 0; i < roadDensity; i++)
        {
            int x = Random.Range(0, gridWidth);
            int y = 0;

            if (x < 9 || x > 12) 
            {
                // 70% chance of placing dirt if it is in the middle for balancing
                if (Random.Range(0, 100) < 70)
                    continue;
                y = Random.Range(13, 17);
            }
            else
            {
                y = Random.Range(0, 30);
            }
            tilemap.SetTile(new Vector3Int(x, y, 0), tbLayer[1]);
        }

        int numFlowers = 24;
        for (int i = 0; i < numFlowers; i++)
        {
            int quadrant = Random.Range(0, 4);
            int flower = Random.Range(0, 12);

            // check if position is occupied
            if (System.Array.IndexOf(occupiedPositions, treePositions[quadrant,flower]) != -1)
                continue;

            GameObject obj = Instantiate(obstacles[2], this.gameObject.transform.position + treePositions[quadrant, flower], Quaternion.identity);
            obj.transform.parent = this.gameObject.transform;
        }

        // generate scenery
        /*
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // 10% chance of skipping a placement
                if (Random.Range(0, 100) < 90)
                    continue;

                int obstacle = Random.Range(0, obstacles.Length);
                GameObject obj = Instantiate(obstacles[obstacle], this.gameObject.transform.position + new Vector3(x, y, 0), Quaternion.identity);
                obj.transform.parent = this.gameObject.transform;
            }
        }
        */
    }
}
