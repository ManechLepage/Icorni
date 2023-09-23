using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            if (item.isGrabable)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
