using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int frogHealth;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isJumping;

    void Awake()
    {
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target) {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        // move the frog if the 'isJumping' flag is set by the animation
        if (isJumping) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * movementSpeed;
        } else {
            rb.velocity = new Vector2(0, 0);
        }
    }
    
    void Jump()
    {
        isJumping = true;
    }

    void EndJump()
    {
        isJumping = false;
    }
}

