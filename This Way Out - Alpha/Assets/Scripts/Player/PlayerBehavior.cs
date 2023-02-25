using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Game Manager
    private GameObject gm;
    
    // Player options
    public float moveSpeed;

    // Animations
    private Animator animator;  

    void Awake()
    {   
        // Get the game manager
        gm = GameObject.FindWithTag("GameManager");

        // Get the animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        // Handle walking movements
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
            Move();
        } 
        else 
        {
            animator.SetBool("isWalking", false);
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
        if (col.gameObject.tag == "Frog" ||
            col.gameObject.tag == "Arrow")
        {
            gm.SendMessage("UpdateHealth", -1);
            if (col.gameObject.tag == "Arrow")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
