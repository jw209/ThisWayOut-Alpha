using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFrog : MonoBehaviour
{
    public GameObject frog;

    void Awake()
    {
        InvokeRepeating("Generator", 0, 10);
    }

    void Generator()
    {
        Instantiate(frog, transform.position, Quaternion.identity);
    }
}
