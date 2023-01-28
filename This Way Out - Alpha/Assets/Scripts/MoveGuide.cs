using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuide : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float guideSpeed;
    [SerializeField] private GameObject prefab;
    private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the guide
        if  (Input.GetAxis("Left Trigger") > 0)
        {
            transform.RotateAround(target.position, new Vector3(0, 0, -change.x), guideSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Right Trigger") > 0)
        {
            transform.RotateAround(target.position, new Vector3(0, 0, -change.x), guideSpeed * Time.deltaTime);
        }

        // fire the projectile
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
        }
    }
}
