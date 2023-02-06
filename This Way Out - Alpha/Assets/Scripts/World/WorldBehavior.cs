using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehavior : MonoBehaviour
{
    // Reference to the map prefab
    public GameObject mapPrefab;

    // Reference to the player
    public Transform player;

    // Dimensions of each map
    private const int MAP_WIDTH = 22;
    private const int MAP_HEIGHT = 30;

    // Current instance of the map
    private GameObject currentMap;

    void Awake()
    {
        // Instantiate the first map
        currentMap = Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        // Check if the player has crossed the bound of the current map
        if (player.position.x >= currentMap.transform.position.x + MAP_WIDTH)
        {
            Vector3 oldPosition = currentMap.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x + MAP_WIDTH, oldPosition.y, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
        else if (player.position.x <= currentMap.transform.position.x)
        {
            Vector3 oldPosition = currentMap.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x - MAP_WIDTH, oldPosition.y, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
        else if (player.position.y >= currentMap.transform.position.y + MAP_HEIGHT)
        {
            Vector3 oldPosition = currentMap.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x, oldPosition.y + MAP_HEIGHT, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
        else if (player.position.y <= currentMap.transform.position.y)
        {
            Vector3 oldPosition = currentMap.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x, oldPosition.y - MAP_HEIGHT, oldPosition.z);
            Destroy(currentMap);
            currentMap = Instantiate(mapPrefab, newPosition, Quaternion.identity);
        }
    }
}