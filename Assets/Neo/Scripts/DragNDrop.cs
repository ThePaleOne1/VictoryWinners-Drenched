using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
