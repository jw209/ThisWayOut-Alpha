using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody2D rb;
    private Transform target;
    
    void Awake()
    {
        if (this.gameObject.tag == "Arrow")
        {
            target = GameObject.FindWithTag("Player").transform;
            Destroy(this.gameObject, 2f);
        }
        rb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        
        if (this.gameObject.tag == "Arrow")
        {
            // Calculate the direction from the arrow's position to the target's position
            Vector3 direction = target.position - transform.position;

            // Calculate the angle between the direction and the arrow's forward vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the arrow to point towards the target
            transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            rb.AddForce(transform.up * projectileSpeed);
        }
        else
        {
            rb.AddForce(transform.up * projectileSpeed);
        }
    }
}
