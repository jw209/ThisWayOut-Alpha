using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuide : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float guideSpeed;
    [SerializeField] private GameObject prefab;
    private Vector3 change;

    // Update is called once per frame
    void Update()
    {
        // move the guide
        if  (Input.GetKey(KeyCode.JoystickButton4))
        {
            transform.RotateAround(target.position, new Vector3(0, 0, 1), guideSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.JoystickButton5))
        {   
            transform.RotateAround(target.position, new Vector3(0, 0, -1), guideSpeed * Time.deltaTime);
        }

        // fire the projectile
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
        }
    }
}