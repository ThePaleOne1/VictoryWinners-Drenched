using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField]
    float Speed = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, Speed*Time.deltaTime,0));
    }
}
