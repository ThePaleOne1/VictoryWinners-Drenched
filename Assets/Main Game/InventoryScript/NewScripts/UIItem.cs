using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem; // when holding the item

    private void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item) // Pass an Item and handle that item and show it on the UI
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white; // sets RBG and Alpha to 255.
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear; // if it is null, it will set RPG and Alpha set to 0.
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        else if (selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }
}
