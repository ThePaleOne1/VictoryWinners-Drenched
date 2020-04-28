using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
public class UICraftResult : MonoBehaviour, IPointerDownHandler
{
    public SlotPanel slotPanel;
    public AudioSource craft;

    public void OnPointerDown(PointerEventData eventData)
    {
        slotPanel.EmptyAllSlots();
        craft.Play();

    }
}