using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    // things the script needs to know about
    public GameObject[] obstacles;
    public TileBase[] tbLayer;
    public int numObstacles = 10;

    // map dimensions
    private const int MAPWIDTH = 22;
    private const int MAPHEIGHT = 30;

    void Awake()
    {
        // get components
        Grid grid = gameObject.GetComponent<Grid>();
        Tilemap tilemap = gameObject.GetComponent<Tilemap>();
        TilemapRenderer renderer = gameObject.GetComponent<TilemapRenderer>();

        // set sorting
        renderer.sortingOrder = 0;

        // generate ground tiles
        for (int x = 0; x < 22; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tbLayer[0]);
            }
        }

        // generate obstacle tiles
        for (int i = 0; i < obstacles.Length; i++)
        {
            Vector3 placement = new Vector3(0,0,0);
            Vector3[] pastPlacements = new Vector3[numObstacles];

            float minX = tilemap.transform.position.x;
            float maxX = tilemap.transform.position.x+MAPWIDTH;
            float minY = tilemap.transform.position.y;
            float maxY = tilemap.transform.position.y+MAPHEIGHT;

            for (int x = 0; x < numObstacles; x++)
            {
                int quadrant = Random.Range(0,4);
                switch (quadrant)
                {
                    case 0:
                        placement = new Vector3(Random.Range(minX, maxX), Random.Range(minY, minY+5), 0);
                        break;
                    case 1:
                        placement = new Vector3(Random.Range(minX, minX+5), Random.Range(minY, maxY), 0);
                        break;
                    case 2:
                        placement = new Vector3(Random.Range(maxX-5, maxX), Random.Range(minY, maxY), 0);
                        break;
                    case 3:
                        placement = new Vector3(Random.Range(minX, maxX), Random.Range(maxY-5, maxY), 0);
                        break;
                }     

                if (System.Array.IndexOf(pastPlacements, placement) == -1 || x == 0)
                {
                    pastPlacements[x] = placement;
                    var tree = Instantiate(obstacles[i], placement, Quaternion.identity);
                    tree.transform.parent = gameObject.transform;
                }
            } 
        }
    } 
}
