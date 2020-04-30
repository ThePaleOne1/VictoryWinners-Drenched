using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasourceScript : MonoBehaviour
{
    [SerializeField] GameObject axe;

    public Inventory AddItem;

    GameObject player;

    PlayerController controller;

    [SerializeField]
    float cooldown = 0.5f;
    bool canInteract = true;

    [SerializeField]
    ResourceMeter resourceMeter;
    Flint flint;
    Fiber Fiber;

    
    Animator anim;

    ItemDatabase database;
    bool axeEnabled = false;
    void Start()
    {
        database = FindObjectOfType<ItemDatabase>();

        AddItem = GameObject.FindObjectOfType<Inventory>();
        
        anim = GetComponent<Animator>();

        player = PlayerManager.instance.player;

        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        //axeEnabled = false;
        //foreach (var item in AddItem.playerItems)
        //{
        //    if (item.id == 1)
        //    {
        //        axeEnabled = true;
        //    }
        //}

        if(AddItem.playerItems.Contains(database.GetItem(1)))
        {
            axe.SetActive(true);
            print("axe found");
        }
        else
        {
            axe.SetActive(false);
            print("axe not found");
        }
    }


    GameObject hitObj;
    private void OnTriggerStay(Collider col)
    {
        if (!controller.Dead)
        {
            if (Input.GetMouseButtonDown(0) && canInteract)
            {
                canInteract = false;


                Invoke("CanInteract", cooldown);
                hitObj = col.gameObject;
                print(hitObj.name);

                if (col.tag == "Tree")
                {
                    anim.SetTrigger("Hit");
                    Invoke("HitTree", cooldown);

                    col.GetComponent<Tree>().isHit = true;

                   
                    
                        AddItem.GiveItem(2);
                        if (axe.activeSelf)
                        {
                            AddItem.GiveItem(1);
                        }
                    
                   

                }

                if (col.tag == "Food")
                {

                    anim.SetTrigger("Pickup");
                    AddItem.GiveItem(4);
                    Invoke("Food", cooldown);

                }

                if (col.tag == "Bush")
                {
                    anim.SetTrigger("Pickup");
                    AddItem.GiveItem(5);
                    Invoke("Bush", cooldown);
                }

                if (col.tag == "Flint")
                {
                    anim.SetTrigger("Pickup");
                    AddItem.GiveItem(3);
                    Invoke("Flint", cooldown);
                    
                }

                if (col.tag == "Threat")
                {
                    anim.SetTrigger("Hit");
                    Invoke("Enemy", cooldown);
                }

            }
        }       
    }

    void CanInteract()
    {
        canInteract = true;
        
    }

    private void HitTree()
    {
        hitObj.GetComponent<Tree>().durability -= 1;
        int spawnChance = Mathf.RoundToInt(Random.value * 10);
        if (spawnChance > 8)
        {
            Instantiate(hitObj.GetComponent<Tree>().coconut,hitObj.transform.position + Random.onUnitSphere + new Vector3(0,10,0), hitObj.transform.rotation);
            
        }
    }

    void Food()
    {
        resourceMeter.food += hitObj.GetComponent<foodItem>().foodAmount;
        Destroy(hitObj);
    }
    void Flint()
    {
        //flint.flintAmount += hitObj.GetComponent<Flint>().flintAmount;
        Destroy(hitObj);
    }

    void Bush()
    {
        //Fiber.fiberAmount += hitObj.GetComponent<Fiber>().fiberAmount;
        Destroy(hitObj);
    }

    void Enemy()
    {
        hitObj.GetComponent<Enemy>().currentHealth -= hitObj.GetComponent<Enemy>().playerDamage;
    }
}
