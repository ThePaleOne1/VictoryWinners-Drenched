using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public GameObject item;

    public void OnDrag(PointerEventData eventData)
    {
        item = GameObject.FindWithTag("ItemImage");

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item = GameObject.FindWithTag("ItemImage");
        transform.localPosition = Vector3.zero;
    }
}