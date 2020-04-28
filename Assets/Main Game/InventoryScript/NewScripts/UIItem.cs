using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem; // when holding the item
    private Tooltip tooltip;
    public bool craftingSlot = false; // it looks if there is a recipe to create stuff
    private CraftingSlots craftingSlots;

    public AudioSource place;

    private void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlots>();
        tooltip = FindObjectOfType<Tooltip>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
            

        }
        else
        {
            spriteImage.color = Color.clear;
            
        }
        if (craftingSlot)
        {
            craftingSlots.UpdateRecipe();
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
                place.Play();

            }
        }
        else if (selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
            place.Play();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.item != null)
        {
            tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }

    public void placeSound()
    {
        
    }
}
