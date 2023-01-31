using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;
    public float minimumY;
    private int screenCenter;
    private float change;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, target.position.y - 2.5f, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        screenCenter = Screen.height / 2;

        if (((target.position.y + screenCenter) - screenCenter) > 20)
        {
            change = Mathf.Lerp(transform.position.y, target.position.y,
                                Time.deltaTime / cameraSpeed);
            transform.position = new Vector3(transform.position.x, 
                                             change,
                                             transform.position.z);
        } else if (((target.position.y + screenCenter) - screenCenter) < 20 && (transform.position.y >= minimumY))
        {
            change = Mathf.Lerp(transform.position.y, target.position.y, 
                                Time.deltaTime / cameraSpeed);
            transform.position = new Vector3(transform.position.x,
                                             change,
                                             transform.position.z);
        }
        if (transform.position.y <= minimumY)
        {
            transform.position = new Vector3(transform.position.x, minimumY, transform.position.z);
        }
    }
}