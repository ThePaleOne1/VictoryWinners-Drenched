using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasourceScript : MonoBehaviour
{
    [SerializeField]
    float cooldown = 0.5f;
    bool canInteract = true;

    

    [SerializeField]
    ResourceMeter resourceMeter;
    
    Animator anim;
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    GameObject hitObj;
    private void OnTriggerStay(Collider col)
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
            }

            if (col.tag == "Food")
            {
                anim.SetTrigger("Pickup");
                Invoke("Food",cooldown);
            }

        }
    }

    void CanInteract()
    {
        canInteract = true;
        
    }

    private void HitTree()
    {
        resourceMeter.wood += 1;
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
}
