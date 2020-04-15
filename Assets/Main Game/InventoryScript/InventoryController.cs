using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Transform selectedItem;
    public Transform selectedSlot;
    public Transform originalSlot;
    public Transform canvas;

    public bool canGrab = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && selectedItem != null)
        {
            selectedItem.GetComponent<Collider>().enabled = false;
            originalSlot = selectedItem.parent;
            selectedItem.SetParent(canvas);
        }
        if(Input.GetMouseButton(0) && selectedItem != null)
        {
            selectedItem.position = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0) && selectedItem != null)
        {
            if (selectedSlot == null)
            {
                selectedItem.SetParent(originalSlot);
            }
            else 
            {
                selectedItem.SetParent(selectedSlot);
               
            }
            selectedItem.localPosition = Vector3.zero;
            selectedItem.GetComponent<Collider>().enabled = true;
        }
           
        }
        
        
    }

