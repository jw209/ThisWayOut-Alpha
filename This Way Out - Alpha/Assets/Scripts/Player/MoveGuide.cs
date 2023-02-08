using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuide : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float guideSpeed;
    [SerializeField] private GameObject prefab;
    private Vector3 change;
    private float bulletCounter;

    void Awake()
    {
        bulletCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // move the guide left
        if  (Input.GetKey(KeyCode.JoystickButton4))
        {
            transform.RotateAround(target.position, new Vector3(0, 0, 1), guideSpeed * Time.deltaTime);
        }
        // move the guide right
        else if (Input.GetKey(KeyCode.JoystickButton5))
        {   
            transform.RotateAround(target.position, new Vector3(0, 0, -1), guideSpeed * Time.deltaTime);
        }

        // fire the projectile
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            // check if bullet is ready to fire
            if (bulletCounter == 0)
                Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
            
            bulletCounter++;

            // reset bullet counter
            if (bulletCounter == 50)
                bulletCounter = 0;
        }
    }
}
