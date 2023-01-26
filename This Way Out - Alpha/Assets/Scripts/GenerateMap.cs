using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    // ground=0, collidables=1, scenery=2
    enum options {ground, collidables, scenery};

    /*
        [0] -> 
        [1] -> 
        [3] ->
        .
        .
        .
    */
    public TileBase[] tb;

    // declaring game objects and the three essential tilemap layers
    private GameObject go;
    private Tilemap layerA, layerB, layerC;

    // generates a tilemap with sortingOrder = sort and a name
    void createLayer(ref GameObject go, ref Tilemap tm, int sort, string gameObjectName)
    {
        // initialize and set components of game object
        go = new GameObject(gameObjectName);
        go.transform.parent = gameObject.transform;
        tm = go.AddComponent(typeof(Tilemap)) as Tilemap;

        // create a renderer for the tilemap
        TilemapRenderer tr = go.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
        tr.sortingOrder = sort;
    }

    void Start()
    {
        // generate ground layer of tiles
        createLayer(ref go, ref layerA, 0, "base");
        GenerateTiles(ref layerA, (int)options.ground);
    }

    void GenerateTiles(ref Tilemap tm, int option)
    {
        switch (option) {
            // generate layerA (strictly ground tiles / non-collidable)
            case 0:
               for (int x=0; x < 22; x++)
                   for (int y=0; y < 30; y++) {
                        tm.SetTile(new Vector3Int(x, y, 0), tb[0]);
                   }
                break;
            // generate layerB (paths)
            case 1:
                break;
            // generate layerC (spawners and scenery)
            case 2:
                break;
        }
    }
}
