using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
            Move();
        } else 
        {
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
