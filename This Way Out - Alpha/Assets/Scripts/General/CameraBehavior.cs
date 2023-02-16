using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // External factors
    private Transform target;
    private Transform player;
    private GameObject world;

    // Camera options
    public float cameraSpeed;
    public float xOffset = 11;
    public float yOffset = 15;

    // Internal variables
    private Vector3 lastPosition; 
    private Vector3 newPos;
    Vector3 mapPosition;
    private float change;
    private float screenCenter;

    void Awake()
    {
        // Get the screen center
        screenCenter = Screen.height / 2;

        // Get the world game object
        world = GameObject.FindWithTag("World");

        // Get the player transform
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Initialize map vector to a zero vector so we can check if it has changed later on
        mapPosition = Vector3.zero;

        // Get the map transform
        target = GameObject.FindWithTag("Map").transform;

        if (target)
        {
            // Get the position of where the map should be
            mapPosition = new Vector3(target.position.x+xOffset, target.position.y+yOffset, -10);
        }

        if (mapPosition != Vector3.zero)
        {
            // If map was set, move the camera to map position
            transform.position = Vector3.Lerp(transform.position, mapPosition, cameraSpeed * Time.deltaTime);
        }

        if (player)
        {   
            // If the player is above the center of the screen, slowly move camera upwards
            if (((player.position.y + screenCenter) - screenCenter) > 20)
            {
                change = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * cameraSpeed+2);
                transform.position = new Vector3(transform.position.x, change, transform.position.z);
            }
            // If the player is below the center of the screen, slowly move camera downwards
            else if (((player.position.y + screenCenter) - screenCenter) < 20)
            {
                change = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * cameraSpeed+2);
                transform.position = new Vector3(transform.position.x, change, transform.position.z);
            }
        } 
    }
}
