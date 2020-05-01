using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPanel : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public int numberOfSlots;
    public GameObject slotPrefabs;
    

    void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefabs);
            instance.transform.SetParent(transform);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
            uiItems[i].item = null;
            
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);

    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item); // if it finds an empty slot, it will add a new item.

    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null); // if the item is the name, it will be remove
        
    }

    public void EmptyAllSlots()
    {
        uiItems.ForEach(i => i.UpdateItem(null));
        
    }

    public bool ContainsEmptySlot()
    {
        foreach(UIItem uii in uiItems)
        {
            if (uii.item == null) return true;
            
        }
        return false;
    }

   
}
