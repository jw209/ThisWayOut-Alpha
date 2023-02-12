using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateMap : MonoBehaviour
{
    // map dimensions
    private const int gridWidth = 22;
    private const int gridHeight = 30;

    // things the script needs to know about
    private GameManager gm;
    private int level;
    private string tilemaps_path = "Assets/Resources/Tilemaps/Tiles/";
    private string scenery_path = "Assets/Resources/Prefabs/Scenery/";
    private string spawners_path = "Assets/Resources/Prefabs/Spawners/";

    // alert game manager that map is initialized
    void Awake()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        level = gm.currentLevel;
        GetResourcesAndBuild();
    }

    public void GetResourcesAndBuild()
    {   
        // get components
        Grid grid = gameObject.GetComponent<Grid>();
        Tilemap tilemap = gameObject.GetComponent<Tilemap>();
        TilemapRenderer renderer = gameObject.GetComponent<TilemapRenderer>();

        // set sorting
        renderer.sortingOrder = 0;

        // get ground tiles
        TileBase[] tiles = new TileBase[Directory.GetFiles(tilemaps_path + "level_" + level).Length/2];
        for (int i = 0; i < Directory.GetFiles(tilemaps_path + "level_" + level).Length/2; i++)
        {
            tiles[i] = Resources.Load<TileBase>("Tilemaps/Tiles/level_" + level + "/tile_" + i);
        }

        // get scenery prefabs
        GameObject[] scenery = new GameObject[Directory.GetFiles(scenery_path + "level_" + level).Length/2];
        for (int i = 0; i < Directory.GetFiles(scenery_path + "level_" + level).Length/2; i++)
        {
            scenery[i] = Resources.Load<GameObject>("Prefabs/Scenery/level_" + level + "/scenery_" + i);
        }
        
        // generate ground tiles
        for (int x = -1; x < gridWidth+2; x++)
        {
            for (int y = -1; y < gridHeight+2; y++)
            {
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

                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[0]);

                if (Random.Range(0, 100) < 50)
                {
                    GameObject obj = Instantiate(scenery[5], this.gameObject.transform.position + new Vector3(x, y, 0), Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                }
            }
        }
        
        // generate scenery
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

        int numTrees = 24;
        Vector3[] occupiedPositions = new Vector3[numTrees];
        // generate trees
        for (int i = 0; i < numTrees; i++)
        {
            int quadrant = Random.Range(0, 4);
            int tree = Random.Range(0, 12);

            occupiedPositions[i] = treePositions[quadrant, tree];

            GameObject obj = Instantiate(scenery[3], this.gameObject.transform.position + treePositions[quadrant, tree], Quaternion.identity);
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
            tilemap.SetTile(new Vector3Int(x, y, 0), tiles[Random.Range(1, 3)]);
        }

        int numFlowers = 24;
        for (int i = 0; i < numFlowers; i++)
        {
            int quadrant = Random.Range(0, 4);
            int flower = Random.Range(0, 12);

            // check if position is occupied
            if (System.Array.IndexOf(occupiedPositions, treePositions[quadrant,flower]) != -1)
                continue;

            GameObject obj = Instantiate(scenery[Random.Range(0,3)], this.gameObject.transform.position + treePositions[quadrant, flower], Quaternion.identity);
            obj.transform.parent = this.gameObject.transform;
        }

        GameObject[] spawners = new GameObject[Directory.GetFiles(spawners_path + "level_" + level).Length/2];
        for (int i = 0; i < Directory.GetFiles(spawners_path + "level_" + level).Length/2; i++)
        {
            spawners[i] = Resources.Load<GameObject>("Prefabs/Spawners/level_" + level + "/spawner_" + i);
        }

        // generate spawners
        int iter = Random.Range(0, 4);
        for (int i = 0; i < iter; i++)
        {
            int x = Random.Range(0, gridWidth);
            int y = Random.Range(0, gridHeight);

            GameObject obj = Instantiate(spawners[0], this.gameObject.transform.position + new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = this.gameObject.transform;

        }
    }
}
