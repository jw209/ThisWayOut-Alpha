using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Transform target;
    public Transform player;
    public GameObject world;
    public float cameraSpeed;
    private Vector3 lastPosition; 
    private Vector3 newPos;
    Vector3 mapPosition;
    private float change;
    private float screenCenter;

    private float xOffset = 11;
    private float yOffset = 15;

    private Vector3 targetPosNow;

    private float changeX;
    private float changeY;

    private float topEdge;
    private float bottomEdge;

    void Update()
    {
        mapPosition = Vector3.zero;
        target = GameObject.FindWithTag("Map").transform;
        if (target)
        {
            mapPosition = new Vector3(target.position.x+xOffset, target.position.y+yOffset, -10);
        }
        if (mapPosition != Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position, mapPosition, cameraSpeed * Time.deltaTime);
        }

        if (player)
        {
            screenCenter = Screen.height / 2;

            if (((player.position.y + screenCenter) - screenCenter) > 20)
            {
                change = Mathf.Lerp(transform.position.y, player.position.y,
                                    Time.deltaTime * cameraSpeed+2);
                transform.position = new Vector3(transform.position.x, 
                                                change,
                                                transform.position.z);
            } else if (((player.position.y + screenCenter) - screenCenter) < 20)
            {
                change = Mathf.Lerp(transform.position.y, player.position.y, 
                                    Time.deltaTime * cameraSpeed+2);
                transform.position = new Vector3(transform.position.x,
                                                change,
                                                transform.position.z);
            }
        } 
    }
}
