using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private GameObject heartA, heartB, heartC;

    void Awake()
    {
        heartA = Instantiate(Resources.Load("UI/heart"),
                             transform.position + new Vector3(0, 0, 0),
                             Quaternion.identity) as GameObject;
        heartA.transform.parent = this.gameObject.transform;

        heartB = Instantiate(Resources.Load("UI/heart"),
                             transform.position + new Vector3(1f, 0, 0),
                             Quaternion.identity) as GameObject;
        heartB.transform.parent = this.gameObject.transform;

        heartC = Instantiate(Resources.Load("UI/heart"),
                             transform.position + new Vector3(2f, 0, 0),
                             Quaternion.identity) as GameObject;
        heartC.transform.parent = this.gameObject.transform;   
    }

    void SetHealth(int currentHealth)
    {
        if (currentHealth == 2 && heartC != null)
        {
            Destroy(heartC);
        }
        else if (currentHealth == 1 && heartB != null)
        {
            Destroy(heartB);
        }
        else if (currentHealth == 0 && heartA != null)
        {
            Destroy(heartA);
        }
    }
}
