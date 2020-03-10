using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMeter : MonoBehaviour
{
    public float Health;
    public float wood;
    public float food;
    public float sanity;
    public float fiber;
    public float flint;

    public float drainFood;

    [SerializeField] StatusScript statusHUD;

    private void Start()
    {
        
    }

    private void Update()
    {
        drainStatus();
    }

    void drainStatus()
    {
        if (food > 0)
        {
            food -= drainFood * Time.deltaTime;
        }
    }
}
