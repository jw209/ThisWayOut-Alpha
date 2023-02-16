using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehavior : MonoBehaviour
{
    // Dimensions of each map
    private const int MAP_WIDTH = 22;
    private const int MAP_HEIGHT = 30;

    // Reference to the map prefab
    private GameObject mapPrefab;

    // Reference to the player
    private Transform player;

    // Current instance of the map
    private GameObject currentMap;

    // New position of the map
    private Vector3 oldPosition;
    private Vector3 newPosition;

    void Awake()
    {   
        // Get the map prefab
        mapPrefab = Resources.Load("Prefabs/Map") as GameObject;

        // Get the player's transform
        player = GameObject.FindWithTag("Player").transform;

        // Instantiate the first map
        currentMap = Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        // Check if the player has crossed the bound of the current map, and if so,
        // destroy old instance and instantiate a new one

        // Check if the player has crossed the right bound
        if (player.position.x >= currentMap.transform.position.x + MAP_WIDTH)
        {
            oldPosition = currentMap.transform.position;
            newPosition = new Vector3(oldPosition.x + MAP_WIDTH, oldPosition.y, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
        // Check if the player has crossed the left bound
        else if (player.position.x <= currentMap.transform.position.x)
        {
            oldPosition = currentMap.transform.position;
            newPosition = new Vector3(oldPosition.x - MAP_WIDTH, oldPosition.y, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
        // Check if the player has crossed the top bound
        else if (player.position.y >= currentMap.transform.position.y + MAP_HEIGHT)
        {
            oldPosition = currentMap.transform.position;
            newPosition = new Vector3(oldPosition.x, oldPosition.y + MAP_HEIGHT, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
        // Check if the player has crossed the bottom bound
        else if (player.position.y <= currentMap.transform.position.y)
        {
            oldPosition = currentMap.transform.position;
            newPosition = new Vector3(oldPosition.x, oldPosition.y - MAP_HEIGHT, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
    }
}