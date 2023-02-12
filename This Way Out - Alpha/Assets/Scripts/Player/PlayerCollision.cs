using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameObject gm;

    void Awake ()
    {
        gm = GameObject.FindWithTag("GameManager");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Frog")
        {
            gm.SendMessage("UpdateHealth", -1);
        }
    }
}
