using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            // frog takes damage
            this.gameObject.GetComponent<FrogStats>()
                .takeDamage(col.gameObject.GetComponent<BulletStats>().attackDamage);
            
            // destroy bullet
            Destroy(col.gameObject);
        }
    }
}
