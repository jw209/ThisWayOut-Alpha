using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private GameObject gm;

    void Awake()
    {
        gm = GameObject.FindWithTag("GameManager");
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gm.SendMessage("UpdateInventory", this.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
