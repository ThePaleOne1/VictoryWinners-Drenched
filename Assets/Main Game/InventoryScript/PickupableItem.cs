using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{

    public Item itemData;


    [SerializeField]
    float cooldown = 0.5f;
    bool canInteract = true;

    private void OnTriggerStay(Collider col)
    {
                    
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            canInteract = false;
            Invoke("CanInteract", cooldown);
            if (col.tag == "Player")
            {
                GameManager.instance.Additem(itemData);
                Invoke("CanInteract", cooldown);
            }
        }
        
    }
    void CanInteract()
    {
        canInteract = true;

    }
}


