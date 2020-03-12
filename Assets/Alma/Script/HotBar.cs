using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour
{
    public Transform original;
    public Transform HotbarSlot;
    public Transform thisSlot;
    public Transform[] Items;

    public GameObject InstObject;
    public int scrollPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y >= 1)
        {
            scrollPosition++;
            if(scrollPosition >= 10)
            {
                scrollPosition = 1;
            } 
            
        }
        if(Input.mouseScrollDelta.y <= -1)
        {
            scrollPosition--;
            if(scrollPosition <= 0)
            {
                scrollPosition = 9;
            }
        }
        Selected();
    }

    void Selected()
    {
        if(thisSlot.name == "HBSlot (" + scrollPosition + ")")
        {
            thisSlot.GetComponent<Image>().color = Color.white;
        }
        else
        {
            thisSlot.GetComponent<Image>().color = original.GetComponent<Image>().color;
        }

    }
}
