using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public Transform from;

    public Transform to;

    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(from.rotation, to.rotation, Time.deltaTime * rotateSpeed);
    }
}
