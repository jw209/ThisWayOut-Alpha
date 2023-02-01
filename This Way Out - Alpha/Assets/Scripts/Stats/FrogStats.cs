using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogStats : MonoBehaviour
{
    public int attackDamage;
    public float attackSpeed;
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
