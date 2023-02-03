using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        rb.AddForce(transform.up * projectileSpeed);
    }
}
