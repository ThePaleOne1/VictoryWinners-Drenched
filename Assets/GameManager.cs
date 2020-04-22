using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //MARKER SINGLETON PATTERN
    public bool isPaused;

    public List<Item> items = new List<Item>(); //How many items we have
    public List<int> itemNumbers = new List<int>(); // HOw many items we have
    public GameObject[] slots;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>(); //Optional
    public Item addItem_01; // add item test
    public Item removeItem_01; // remove item test
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        DisplayItems();
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Additem(addItem_01);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RemoveItem(removeItem_01);
        }
    }
    private void DisplayItems()
    {
        #region
        //for (int i = 0; i < items.Count; i++)
        //{
        //    slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

        //    slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
        //    slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

        //    slots[i].transform.GetChild(1).gameObject.SetActive(true);
        //    slots[i].transform.GetChild(2).gameObject.SetActive(true);
        //}
        #endregion

        for(int i = 0; i < slots.Length; i++)
        {
               if (i < items.Count)
                {
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                    slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                    slots[i].transform.GetChild(1).gameObject.SetActive(true);
                    slots[i].transform.GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                    slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                    slots[i].transform.GetChild(1).gameObject.SetActive(false);
                    slots[i].transform.GetChild(2).gameObject.SetActive(false);
                }
        }
       
    }

    public void Additem(Item _item)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("You have already have this item");
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }

        }
        DisplayItems();
    }


    public void RemoveItem(Item _item)
    {
        if (items.Contains(_item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("No Items" + _item + " in my bags");
        }
        DisplayItems();
    }

}

