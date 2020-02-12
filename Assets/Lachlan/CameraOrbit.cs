using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField]
    GameObject anchorObj;

    [SerializeField]
    float minScrollDistance = 10;
    [SerializeField]
    float maxScroolDistance = 100;
    [SerializeField]
    float minTiltAngle = 80;
    [SerializeField]
    float maxTiltAngle = 30;

    [SerializeField]
    float rotateSpeed = 0.5f;
    [SerializeField]
    float tiltSpeed = 0.5f;

    [SerializeField]
    float scrollSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(anchorObj.transform.position);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * rotateSpeed * Vector3.Distance(transform.position, anchorObj.transform.position)/maxScroolDistance);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * rotateSpeed * Vector3.Distance(transform.position, anchorObj.transform.position)/maxScroolDistance);
        }

        if (Input.GetKey(KeyCode.W) && transform.rotation.eulerAngles.x < maxTiltAngle)
        {
            transform.Translate(Vector3.up * tiltSpeed * Vector3.Distance(transform.position, anchorObj.transform.position) / maxScroolDistance);
        }

        if (Input.GetKey(KeyCode.S) && transform.rotation.eulerAngles.x > minTiltAngle)
        {
            transform.Translate(Vector3.down * tiltSpeed * Vector3.Distance(transform.position, anchorObj.transform.position) / maxScroolDistance);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Vector3.Distance(transform.position, anchorObj.transform.position) < maxScroolDistance)
        {
            transform.Translate(Vector3.back * scrollSpeed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Vector3.Distance(transform.position, anchorObj.transform.position) > minScrollDistance)
        {
            transform.Translate(Vector3.forward * scrollSpeed);
        }
    }
}
