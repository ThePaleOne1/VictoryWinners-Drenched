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


    private void OnTriggerStay(Collider col)
    {
        if (Input.GetMouseButtonDown(0) && canInteract) 
        {
            canInteract = false;
            anim.SetTrigger("Hit");
            Invoke("CanInteract", cooldown);


            if (col.tag == "Tree")
            {
                resourceMeter.wood += 1;
            }
        }
    }

    void CanInteract()
    {
        canInteract = true;
    }
}
