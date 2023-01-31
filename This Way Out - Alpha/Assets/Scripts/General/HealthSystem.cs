using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int health; 

    void Awake()
    {
        health = maxHealth;
    }

    public void takeDamage()
    {
        health -= 1;
    }
}
