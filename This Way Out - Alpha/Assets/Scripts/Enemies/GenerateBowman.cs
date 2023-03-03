using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBowman : MonoBehaviour
{
    private GameObject bowman;

    // Start is called before the first frame update
    void Awake()
    {
        // Load the bowman prefab
        bowman = Resources.Load("Prefabs/Enemies/level_0/enemy_1") as GameObject;

        InvokeRepeating("Generator", 0, 10);
    }

    // Update is called once per frame
    void Generator()
    {
        Instantiate(bowman, transform.position, Quaternion.identity);
    }
}
