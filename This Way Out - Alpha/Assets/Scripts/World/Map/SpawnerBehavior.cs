using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject spawner;
    private Vector3[] spawnerLocations;
    public int numSpawners;

    // set the location of the spawners
    void Awake()
    {
        spawnerLocations = new Vector3[numSpawners];

        for (int i = 0; i < numSpawners; i++)
        {
            spawnerLocations[i] = new Vector3(Random.Range(-11, 11), Random.Range(-10, 20), 0);
        }

        for (int i = 0; i < numSpawners; i++) 
        {
            Instantiate(spawner, spawnerLocations[i], Quaternion.identity);
        }
    }
}
