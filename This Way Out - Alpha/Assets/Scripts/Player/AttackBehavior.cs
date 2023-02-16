using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    // Attack options
    public float guideSpeed;

    // Player transform
    private Transform target;
    
    // Internal variables
    private GameObject prefab;
    private Vector3 change;
    private float bulletCounter;

    void Awake()
    {
        // Get the player transform
        target = GameObject.FindWithTag("Player").transform;

        // Load the star prefab
        prefab = Resources.Load("Prefabs/Items/Weapons/level_0/star_0") as GameObject;

        // Set the bullet counter
        bulletCounter = 0;
    }

    void Update()
    {
        // Move the guide left
        if  (Input.GetKey(KeyCode.JoystickButton4))
        {
            transform.RotateAround(target.position, new Vector3(0, 0, 1), guideSpeed * Time.deltaTime);
        }
        // Move the guide right
        else if (Input.GetKey(KeyCode.JoystickButton5))
        {   
            transform.RotateAround(target.position, new Vector3(0, 0, -1), guideSpeed * Time.deltaTime);
        }

        // Fire the projectile
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            // Check if bullet is ready to fire
            if (bulletCounter == 0)
                Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
            
            bulletCounter++;

            // Reset bullet counter
            if (bulletCounter == 50)
                bulletCounter = 0;
        }
    }
}
