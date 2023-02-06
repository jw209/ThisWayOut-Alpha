using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    public float moveSpeed;
    private Animator animator;  

    void Awake()
    {   
        // get player stats
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        moveSpeed = playerStats.moveSpeed;

        // get animator
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        // handle movement
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
}
