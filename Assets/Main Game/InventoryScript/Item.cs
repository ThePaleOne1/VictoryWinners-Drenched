using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform Inventory;
    public InventoryController inventoryController;
    void Update()
    {
        OnMouseEnter();
        OnMouseExit();
    }

    void OnMouseEnter()
    {
        inventoryController.selectedItem = this.transform;
    }

    void OnMouseExit()
    {

    }
}
