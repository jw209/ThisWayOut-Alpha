using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float flashDuration;
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int frogHealth;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target) {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        // move the front if the 'isJumping' flag is set by the animation
        if (isJumping) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * movementSpeed;
        } else {
            rb.velocity = new Vector2(0, 0);
        }

        // if the frog has 0 health, destroy it
        if (frogHealth <= 0) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        frogHealth--;
        Flash();
    }

    private IEnumerator FlashRoutine() {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
    }

    void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
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

