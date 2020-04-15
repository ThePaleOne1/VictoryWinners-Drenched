using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIventoryItem
{
    string Name { get; }

    Sprite Image { get;  }

    void OnPickup();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IIventoryItem item)
    {
        Item = item;
    }

    public IIventoryItem Item;
}