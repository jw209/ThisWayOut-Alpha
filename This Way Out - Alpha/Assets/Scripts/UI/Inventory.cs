using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public void AddToInventory(int item)
    {
        Vector3 slot = GameObject.FindWithTag("slot1").transform.position;
        GameObject inventory_item = Resources.Load("Prefabs/Items/Inventory/inventory_"+item) as GameObject;
        GameObject instance = Instantiate(inventory_item, slot, Quaternion.identity);
        instance.transform.parent = GameObject.FindWithTag("inventory").transform;
    }
}
