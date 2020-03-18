using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunGoku : MonoBehaviour
{
    public float rotateSpeed;

    public float angleZ;

    public bool dayTime;

    public float drainSanity;

    public GameObject dayNNite;

    [SerializeField] ResourceMeter statusStuff;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
       transform.LookAt(Vector3.zero);

       angleZ = dayNNite.transform.eulerAngles.z;

       DayCycle();
    }

    void DayCycle()
    {
        NightTime();
        DayTime();

        if (dayTime)
        {
            Debug.Log("IT'S DAY");
        }

        if (!dayTime)
        {
            Debug.Log("IT'S NIGHT");

            statusStuff.sanity -= drainSanity * Time.deltaTime;
        }
    }

    void NightTime()
    {
        if (angleZ > 120)
        {           
            dayTime = false;           
        }
    }

    void DayTime()
    {
        if(angleZ < 120)
        {
            dayTime = true;
        }
    }   
}
