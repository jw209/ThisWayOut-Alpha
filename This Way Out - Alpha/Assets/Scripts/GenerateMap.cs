using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    // declare arrays holding layer game objects, tilemaps, and tilemap renderers
    private GameObject layerAGo, layerBGo, layerCGo;
    private Tilemap layerAtm, layerBtm, layerCtm;
    private TilemapRenderer layerAtr, layerBtr, layerCtr;

    // declare 3 TileBase arrays to hold tilebases for the 3 essential layers
    public TileBase[] tbLayerA;
    public TileBase[] tbLayerB;
    public TileBase[] tbLayerC;

    void GenerateTiles()
    {
        for (int x=0; x < 22; x++) 
        {
            for (int y = 0; y < 30; y++) 
            {
                layerAtm.SetTile(new Vector3Int(x, y, 0), tbLayerA[0]);
            }
        }

        for (int x = 0; x < 22; x+=4)
        {
            for (int y = 0; y < 30; y+=4)
            {
                layerBtm.SetTile(new Vector3Int(x, y, 0), tbLayerB[0]);
            }
        }

        for (int x = 0; x < 22; x+=2)
        {
            for (int y = 0; y < 30; y+=2)
            {
                layerCtm.SetTile(new Vector3Int(x, y, 0), tbLayerC[0]);
            }
        }
    }

    void Start()
    {
        // initialize ground tiles
        layerAGo = new GameObject("layerA");
        layerAGo.transform.parent = gameObject.transform;
        layerAtm = new Tilemap();
        layerAtm = layerAGo.AddComponent(typeof(Tilemap)) as Tilemap;
        layerAtr = new TilemapRenderer();
        layerAtr = layerAGo.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
        layerAtr.sortingOrder = 0;

        // initialize obstacle tiles
        layerBGo = new GameObject("layerB");
        layerBGo.transform.parent = gameObject.transform;
        layerBtm = new Tilemap();
        layerBtm = layerBGo.AddComponent(typeof(Tilemap)) as Tilemap;
        layerBtr = new TilemapRenderer();
        layerBtr = layerBGo.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
        layerBtr.sortingOrder = 1;

        // initialize spawner tiles
        layerCGo = new GameObject("layerC");
        layerCGo.transform.parent = gameObject.transform;
        layerCtm = new Tilemap();
        layerCtm = layerCGo.AddComponent(typeof(Tilemap)) as Tilemap;
        layerCtr = new TilemapRenderer();
        layerCtr = layerCGo.AddComponent(typeof(TilemapRenderer)) as TilemapRenderer;
        layerCtr.sortingOrder = 2;

        // generate tiles
        GenerateTiles();
    }    
}
