using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasourceScript : MonoBehaviour
{

    public Inventory AddItem;

    GameObject player;

    PlayerController controller;

    [SerializeField]
    float cooldown = 0.5f;
    bool canInteract = true;

    [SerializeField]
    ResourceMeter resourceMeter;
    
    Animator anim;
    void Start()
    {
        AddItem = GameObject.FindObjectOfType<Inventory>();
        
        anim = GetComponent<Animator>();

        player = PlayerManager.instance.player;

        controller = GetComponent<PlayerController>();
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
                    Invoke("Bush", cooldown);
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

    void Bush()
    {
        hitObj.GetComponent<Bush>().BushHit();
        //resourceMeter.fiber += hitObj.GetComponent<Bush>().fiberAmmount;
    }

    void Enemy()
    {
        hitObj.GetComponent<Enemy>().currentHealth -= hitObj.GetComponent<Enemy>().playerDamage;
    }
}
