using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float leftBound, rightBound, lowBound;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0
            && transform.position.x > leftBound && transform.position.x < rightBound)
        {
            animator.SetBool("isWalking", true);
            Move();
        } else 
        {
            if (transform.position.x <= leftBound)
            {
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            } else if (transform.position.x >= rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            } else if (transform.position.y <= lowBound)
            {
                transform.position = new Vector3(transform.position.x, lowBound, transform.position.z);
            }

            animator.SetBool("isWalking", false);
        }

        
    }

    void Move() {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        animator.SetFloat("walkHorizontal", x);
        animator.SetFloat("walkVertical", y);   
        transform.position += new Vector3(x, y, 0);
    }
}
