using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed;
    public int currentHealth;

    public void takeDamage(int incomingDamage)
    {
        currentHealth -= incomingDamage;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
