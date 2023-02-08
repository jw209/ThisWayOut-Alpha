using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public int currentExperience = 0;
    public int experienceToLevel = 13;
    private string prefabName = "";
    private GameObject instance = null;

    void Awake()
    {
        currentExperience = 0;
        prefabName = "Prefabs/xp/xpbar_"+currentExperience;
        GameObject prefab = Resources.Load(prefabName) as GameObject;
        instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }

    void NextLevel()
    {
        Debug.Log("NextLevel called");
        ++currentExperience;
        prefabName = "Prefabs/xp/xpbar_"+currentExperience;
        GameObject prefab = Resources.Load(prefabName) as GameObject;
        Destroy(instance);
        instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}
