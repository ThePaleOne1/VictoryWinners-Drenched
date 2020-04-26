using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMeter : MonoBehaviour
{
    public float maxValue = 101;

    public float Health;
    public float food;
    public float sanity;

    public float drainFood;
    public float drainHealth;

    GameObject player;

    PlayerController controller;

    [SerializeField] StatusScript statusHUD;

    private void Start()
    {
        player = PlayerManager.instance.player;

        controller = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
       if(Health <= 0)
       {
            Health = 0f;

            Dieded();
       }

      

        drainStatus();

        SanityEffects();
    }

    void drainStatus()
    {
        if (food > 0)
        {
            food -= drainFood * Time.deltaTime;

            if(Health < 100)
            {
                Health += drainHealth / 2 * Time.deltaTime;
            }
        }

        if(food <= 0)
        {
            if(Health >= 10)
            {
                Health -= drainHealth * Time.deltaTime;
            } 
        }
    }

    void MaxStatus()
    {
       if(Health > 100)
       {
          Health = 100f;
       }

       if(food > 100)
       {
          food = 100f;
       }

       if(sanity > 100)
       {
          sanity = 100f;
       }
    }

    public void PlayerDamage()
    {
        if (Health > 0)
        {
            Health -= 10 * Time.deltaTime;
        }
    }

    public void SanityEffects()
    {
        if(sanity < 50)
        {
            controller.sprintEnabled = false;
        }
        else
        {
            controller.sprintEnabled = true;
        }

        if(sanity < 10)
        {
            if(food > 0)
            {
                food -= drainFood * 2 * Time.deltaTime;
            }

            if (Health > 0)
            {
                Health -= drainHealth * 2 * Time.deltaTime;
            }
        }
        
    }

    public void Dieded()
    {
        player.GetComponent<Animator>().SetBool("Dead", true);

        controller.Dead = true;
    }
}
