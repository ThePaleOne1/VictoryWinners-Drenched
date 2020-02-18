using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
<<<<<<< HEAD
    private float ZPosition;

    private Vector3 offset;

    Camera MainCamera;

    bool Dragging;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
=======
    private GameObject itemDrag;

    private Vector3 screenPosition;

    private Vector3 offset;

    private float planeY;

    private float distance;

    Camera MainCamera;

    

    //bool Dragging;

    // Start is called before the first frame update
    void Start()
    {
        //Transform draggingObject;

        //Plane plane = new Plane(Vector3.up, Vector3.up * planeY);

        //Ray ray = MainCamera.PointScreenToRay(Input.mousePosition);

        

        MainCamera = Camera.main;
>>>>>>> master
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
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
=======
        if (itemDrag == null && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if(gameObject == hit.transform.gameObject)
                {
                    itemDrag = hit.transform.gameObject;
                    screenPosition = MainCamera.ScreenToWorldPoint(itemDrag.transform.position);
                    offset = itemDrag.transform.position - MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));

                    print("dragging");
                }
                
            }
        }

        

        //if (plane.Raycast(ray, out distance))
        //{
        //    draggingObject.position = ray.GetPoint(distance);
        //}

        if (Input.GetMouseButtonUp(0))
        {
            itemDrag = null;
        }

        if(itemDrag != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 curPosition = MainCamera.ScreenToWorldPoint(position) + offset;
            itemDrag.transform.position = new Vector3(curPosition.x, itemDrag.transform.position.y, curPosition.z);
        }
>>>>>>> master
    }
}
