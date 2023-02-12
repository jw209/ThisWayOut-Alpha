using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private string prefabName = "";
    private GameObject instance = null;
    private int xp_filler;

    void Awake()
    {
        xp_filler = 0;
        prefabName = "UI/xp/xpbar_0";
        GameObject prefab = Resources.Load(prefabName) as GameObject;
        instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }

    void SetXP()
    {
        xp_filler++;
        prefabName = "UI/xp/xpbar_" + xp_filler;
        GameObject prefab = Resources.Load(prefabName) as GameObject;
        Destroy(instance);
        instance = Instantiate(prefab, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}
