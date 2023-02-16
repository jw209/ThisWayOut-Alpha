using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFrog : MonoBehaviour
{
    private GameObject frog;

    void Awake()
    {
        // Load the frog prefab
        frog = Resources.Load("Prefabs/Enemies/level_0/enemy_0") as GameObject;

        InvokeRepeating("Generator", 0, 10);
    }

    void Generator()
    {
        Instantiate(frog, transform.position, Quaternion.identity);
    }
}
