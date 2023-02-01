using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Frog")
        {
            this.gameObject.GetComponent<PlayerStats>()
                .takeDamage(col.gameObject.GetComponent<FrogStats>().attackDamage);
        }
    }
}
