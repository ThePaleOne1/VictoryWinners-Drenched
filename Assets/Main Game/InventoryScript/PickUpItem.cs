using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDes;
    public GameObject item;

    public Sprite itemSprite;
    private List<Item> items;

    public Item(List<Item> items)
    {
        this.items = items;
    }
}