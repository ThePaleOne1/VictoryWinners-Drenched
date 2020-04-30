using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField] ResourceMeter resource;

    [SerializeField]
    float Speed = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, Speed*Time.deltaTime,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            resource.Health -= 5 * Time.deltaTime;
        }
    }
}
