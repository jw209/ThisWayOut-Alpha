using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{

    public TileBase[] tb;
    public TileBase[] tb1;
    private Tilemap tm1, tm2;
    private GameObject go1, go2;
    void Start()
    {
        // create base tiles
        go1 = new GameObject("base");
        go1.transform.parent = gameObject.transform;
        tm1 = go1.AddComponent(typeof(Tilemap)) as Tilemap;
        TilemapRenderer tr1 = go1.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
        tr1.sortingOrder = 0;

        // create road tiles
        go2 = new GameObject("roads");
        go2.transform.parent = gameObject.transform;
        tm2 = go2.AddComponent(typeof(Tilemap)) as Tilemap;
        TilemapRenderer tr2 = go2.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
        tr2.sortingOrder = 1;

        GenerateBaseTiles();
        GenerateRoadTiles();
    }

    // array [plain, vertical, horizontal, split]
    void GenerateBaseTiles()
    {
        for (int x = 0; x < 22; x++) {
            for (int y = 0; y < 10; y++) {
                tm1.SetTile(new Vector3Int(x, y, 0), tb[0]);                
            }
        }
    }

    void GenerateRoadTiles()
    {   
        // 1) randomly select a coordinate(x, 0)
        // 2) place that coordinate and keep track of x
        // 3) place another tile at (x, 1)...(x, 2)...
        // 4) 0-road vertical
        //    1-road horizontal
        //    2-road split
        //    3-road turn up left
        //    4-road turn up right
        int y = 0;
        int x = Random.Range(0, 22);
        int road = Random.Range(0, 5);
        int last_road;
        while(y <= 10) {
            if (y == 0) {
                tm2.SetTile(new Vector3Int(x, y, 0), tb1[0]);
            } else {
                tm2.SetTile(new Vector3Int(x, y, 0), tb1[road]);
                last_road = x;
            }
            y++;
        }
    }
}
