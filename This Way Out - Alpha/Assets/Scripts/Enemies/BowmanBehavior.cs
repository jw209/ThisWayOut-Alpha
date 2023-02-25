using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowmanBehavior : MonoBehaviour
{
    // Game Manager
    private GameObject gm;

    // Bowman options
    public int attackDamage = 1;
    public int currentHealth = 10;

    // External factors
    private Transform target;
    private GameObject arrow;

    // Internal variables
    private bool shouldShoot = false;

    // Start is called before the first frame update
    void Awake()
    {
        arrow = Resources.Load("Prefabs/Items/Weapons/level_0/arrow_0") as GameObject;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShoot)
        {
            GameObject instance = Instantiate(arrow, transform.position, Quaternion.identity);
            shouldShoot = false;
        }
    }

    public void Shoot()
    {
        shouldShoot = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            --currentHealth;
            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
