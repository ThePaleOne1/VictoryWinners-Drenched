using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Transform Inventory;
    public InventoryController inventoryController;
    
    
   
    void OnMouseEnter()
    {
        inventoryController.selectedSlot = this.transform;
    }

    void OnMouseExit()
    {
       
        inventoryController.selectedSlot = null;
    }
}
