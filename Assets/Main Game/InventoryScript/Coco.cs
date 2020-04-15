using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coco : MonoBehaviour, IIventoryItem
{
    public string Name
    {
        get
        {
            return "Coconut";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        // Add a logic what happens when axe is picked up by player
        gameObject.SetActive(false);
    }

}

    
