using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float guideSpeed;
    [SerializeField] private GameObject prefab;
    private Vector3 change;
    private float bulletCounter;
    private GameObject gm;
    public float moveSpeed;
    private Animator animator;  

    void Awake()
    {   
        gm = GameObject.FindWithTag("GameManager");

        // get animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        // handle walking movements
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
            Move();
        } 
        else 
        {
            animator.SetBool("isWalking", false);
        }


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

    void Move() 
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        animator.SetFloat("walkHorizontal", x);
        animator.SetFloat("walkVertical", y);   
        transform.position += new Vector3(x, y, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Frog")
        {
            gm.SendMessage("UpdateHealth", -1);
        }
    }
}
