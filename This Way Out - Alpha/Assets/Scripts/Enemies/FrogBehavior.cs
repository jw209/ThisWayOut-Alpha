using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    // Game Manager
    private GameObject gm;

    // Frog options
    public int attackDamage = 1;
    public int currentHealth = 10;
    public float movementSpeed = 5;

    // External factors
    private Transform target;
    private AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float flashTime = 0.5f;
    private Color originalColor;
    private SpriteRenderer rend;

    // Internal variables
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isJumping = false;

    void Awake()
    {   
        // Get the game manager
        gm = GameObject.FindWithTag("GameManager");

        // Get renderer
        rend = GetComponent<SpriteRenderer>();

        // Get original color
        originalColor = rend.color;

        // Get the audio source
        audioSource = GetComponent<AudioSource>();

        // Get the player's transform
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the frog's rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target) {
            // If player exists, move set the frogs move direction to the player
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        // Move the frog if the 'isJumping' flag is set by the animation
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
            takeDamage();
            
            Destroy(col.gameObject);
        }
    }

    public void takeDamage()
    {
        FlashRed();
        currentHealth -= 1;
        audioSource.PlayOneShot(audioClipArray[0]);

        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        // Tell game manager that player earned xp for killing a frog
        gm.SendMessage("IncrementXP", 1);
    }

    public void FlashRed()
    {
        rend.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    public void ResetColor()
    {
        rend.color = originalColor;
    }
}

