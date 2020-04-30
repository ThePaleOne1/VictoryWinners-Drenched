using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, "Flint Axe", "An axe made of Flint.",
            new Dictionary<string, int> {
                { "Added", 3 },
                { "Defence", 0 }
            }),

            new Item(2, "Wood", "Use for crafting.",
            new Dictionary<string, int> {
                { "Value", 0 },
                
            }),

            new Item(3, "Flint", "Use for crafting.",
            new Dictionary<string, int> {
                { "Value", 0 },

            }),

            new Item(4, "Coconut", "It can be consume.",
            new Dictionary<string, int> {
                { "+ Hunger", 5 },

            }),

            new Item(5, "Fiber", "Use for crafting.",
            new Dictionary<string, int> {
                { "Value", 0 },

            }),

            new Item(6, "Raft Plank", "4 of these we can make a raft.",
            new Dictionary<string, int> {
                { "Value", 0 },

            }),

            new Item(7, "Sail", "Help the raft to sail at sea.",
            new Dictionary<string, int> {
                { "Value", 0 },

            }),

        };
    }
}
