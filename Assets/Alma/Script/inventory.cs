using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject oneSlot;
    public GameObject notSelected;
    public GameObject CraftComplete;
    public bool ifSelected;

    public void Start()
    {
        oneSlot.gameObject.SetActive(false);
        notSelected.gameObject.SetActive(true);
        CraftComplete.gameObject.SetActive(false);
        ifSelected = false;
    }

    public void firstSlot()
    {
        ifSelected = true;
        oneSlot.gameObject.SetActive(true);
        notSelected.gameObject.SetActive(false);
    }

    public void Craft()
    {
        if (ifSelected)
        {
            CraftComplete.gameObject.SetActive(true);
        }
        
    }

}
