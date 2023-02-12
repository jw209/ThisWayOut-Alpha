using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    Quaternion rotation;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate the compass indefinitely
        transform.Rotate(0, 0, 1);
        /*
        // get the direction to the target
        Vector3 direction = target.transform.position - player.transform.position;
        // get the angle to the target
        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.(newDirection);
        */

        /*
        // get the direction to the target
        Vector3 direction = target.transform.position - player.transform.position;
        // get the angle to the target
        float angle = Mathf.Atan2(direction.y, direction.x+90) * Mathf.Rad2Deg;
        // rotate the player to face the target
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        */
    }
}
