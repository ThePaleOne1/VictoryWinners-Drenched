using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private float ZPosition;

    private Vector3 offset;

    Camera MainCamera;

    bool Dragging;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(offset.x, offset.z));
        }   
    }

    void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDragging();
        }
    }

    void OnMouseUp()
    {
        EndDragging();
    }

    public void BeginDragging()
    {
        Dragging = true;
        offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    public void EndDragging()
    {
        Dragging = false;
    }
}
