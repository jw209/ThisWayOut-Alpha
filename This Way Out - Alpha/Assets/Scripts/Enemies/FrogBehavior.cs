using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    // FROG STATS 
    public int attackDamage;
    public float attackSpeed;
    public float moveSpeed;
    public int currentHealth;
    public int deadFrogs;

    // XP
    private GameObject gm;

    // FROG BEHAVIOR
    private Transform target;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int frogHealth;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isJumping;

    void Awake()
    {
        gm = GameObject.FindWithTag("GameManager");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // FROG STAT METHODS
    public void takeDamage()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            // take damage
            takeDamage();
            
            // destroy bullet
            Destroy(col.gameObject);
        }
    }
    
    void OnDestroy()
    {
        // tell game manager that player earned xp for killing a frog
        gm.SendMessage("IncrementXP", 1);
    }
}

