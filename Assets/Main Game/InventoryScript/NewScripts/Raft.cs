using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Raft : MonoBehaviour
{
    public GameObject[] raft;
    public CraftingSlots craft;
    public CraftRecipe crafted;

    public Inventory inv;
    //

    public ItemDatabase items;

    public bool haveRaft;

    public void Start()
    {


        raft[0].gameObject.SetActive(false);
        raft[1].gameObject.SetActive(false);

        if (inv.playerItems.Any((item) => item.haveRaft == true))
        {
            Debug.Log("We have raft");

            haveRaft = true;
            return;
        }
        else
        {
            Debug.Log("We don't have raft");
            haveRaft = true;

        }


    }


    public void FixedUpdate()
    {
        if (inv.playerItems.Any((item) => item.haveRaft == true))
        {
            Debug.Log("We have raft");

            haveRaft = true;
            return;
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (Input.GetMouseButtonDown(0) && haveRaft == true)
        {
            //if (col.tag == "Raft")
            //{
            //    Debug.Log("is here!");
            //    raft[0].gameObject.SetActive(true);
            //    raft[1].gameObject.SetActive(true);

            //}
            if (inv.playerItems.Any((item) => item.haveRaft == true))
            {
                haveRaft = true;
                if (col.tag == "Raft")
                {
                    haveRaft = true;
                    Debug.Log("is here!");
                    raft[0].gameObject.SetActive(true);
                    raft[1].gameObject.SetActive(true);

                }
            }



        }
        else
        {
            Debug.Log("Stop, you don't have raft");
        }
    }
}

