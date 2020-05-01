using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public int id;
    public string title;
    public string description;
    public bool haveRaft;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string description, bool haveRaft, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.haveRaft = haveRaft;
        this.icon = Resources.Load<Sprite>("Items/" + title);
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.haveRaft = item.haveRaft;
        this.icon = item.icon;
        this.stats = item.stats;
    }
 
}
