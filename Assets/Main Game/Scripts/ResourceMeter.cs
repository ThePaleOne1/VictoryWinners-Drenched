using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMeter : MonoBehaviour
{
    public float maxValue = 101;

    public float Health;
    public float wood;
    public float food;
    public float sanity;
    public float fiber;
    public float flint;

    public float drainFood;
    public float drainHealth;

    [SerializeField] StatusScript statusHUD;

    private void Start()
    {
        
    }

    private void Update()
    {
        //MaxDrainStatus();

        drainStatus();
    }

    void drainStatus()
    {
        if (food > 0)
        {
            food -= drainFood * Time.deltaTime;
        }

        if(food <= 0)
        {
            if(Health >= 10)
            {
                Health -= drainHealth * Time.deltaTime;
            } 
        }
    }

    public void PlayerDamage()
    {
        if (Health > 0)
        {
            Health -= 10 * Time.deltaTime;
        }
    }

    //void MaxDrainStatus()
    //{
    //    if(Health > maxValue)
    //    {
    //        Health -= 1 * Time.deltaTime;
    //    }

        
    //}
}
