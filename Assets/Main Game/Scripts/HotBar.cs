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
        if(HotbarSlot.childCount != 0 && thisSlot.childCount == 1)
        {
            for(int i = 0; i < Items.Length; i++)
            {
                if (HotbarSlot.GetChild(0).name == Items[i].name)
                {
                    InstObject = (GameObject)(Instantiate(Items[i].gameObject, Vector3.zero, Quaternion.identity));
                    InstObject.transform.SetParent(thisSlot.transform);
                    InstObject.transform.localPosition = Vector3.zero;
                    InstObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    thisSlot.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                    return;
                }
            }
            
        }


        if(Input.mouseScrollDelta.y >= 1)
        {
            scrollPosition++;
            if(scrollPosition >= 8)
            {
                scrollPosition = 1;
            } 
            
        }
        if(Input.mouseScrollDelta.y <= -1)
        {
            scrollPosition--;
            if(scrollPosition <= 0)
            {
                scrollPosition = 7;
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
