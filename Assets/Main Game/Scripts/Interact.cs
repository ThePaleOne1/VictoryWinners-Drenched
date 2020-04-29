using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;




public class Interact : MonoBehaviour
{

    public float displayDur = 3f;

    //public Inventory inventory;

    public string[] opening = new string[] { "Oh Look", "Oh dear", "Yummy", "Crap" };
    public string[] middle = new string[] { "a Corona Virus,", "a tin can of tuna,", "It's empy," };
    public string[] ending = new string[] {"so lucky to have me.", "great, I'm allergic to it. Thanks Devs.", "all thanks to Lachlan, " +
                                    "please stahp this!"};

    public Vector3[] HealthWoodFood;
    public Vector3[] SanityFiberFlint;
    public ResourceMeter rm;


    public bool suitcase;
    public GameObject toolTip;
    public GameObject itemDescribe;
    
    public GameObject recipeBook;
    public Text description;

    public float countDown = 0.5f;

    Animator anim;

    int openIndex;
    int midIndex;
    int endIndex;

    public string getRandomItem()
    {

        openIndex = Random.Range(0, opening.Length);
        midIndex = Random.Range(0, middle.Length);
        endIndex = Random.Range(0, ending.Length);

        string itemWording =
            opening[openIndex] + ", " +
            middle[midIndex] + " " +
            ending[endIndex];

        return itemWording;
    }




    private void Start()
    {
        toolTip.gameObject.SetActive(false);
        itemDescribe.gameObject.SetActive(false);
        
        recipeBook.gameObject.SetActive(false);

        //effects.Add(new Vector3(health, food, wood), new Vector3(sanity, 0, 0));



    }

    private void Update()
    {
        if (suitcase && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CoronaVirus());

        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {

            ShowMouseCursor();
            
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {

                HideMouseCursor();
                
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (recipeBook.gameObject.activeInHierarchy == false)
            {
                GameObject.FindObjectOfType<CharacterController>().enabled = false;
                recipeBook.gameObject.SetActive(true);
                
                Time.timeScale = 0f;
                
                ShowMouseCursor();
            }
            else if (recipeBook.gameObject.activeInHierarchy == true)
            {
                GameObject.FindObjectOfType<CharacterController>().enabled = true;
                recipeBook.gameObject.SetActive(false);
                Time.timeScale = 1f;
                HideMouseCursor();
            }
        }
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{

    //    IIventoryItem item = hit.collider.GetComponent<IIventoryItem>();
    //    if(item != null)
    //    {
    //        inventory.addedItem(item);
    //    }
    //}



    public void ShowMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void HideMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Suitcase"))
        {

            toolTip.gameObject.SetActive(true);
            suitcase = true;
            //anim.SetTrigger("Pickup");


        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Suitcase"))
        {

            toolTip.gameObject.SetActive(false);
            suitcase = false;
            itemDescribe.gameObject.SetActive(false);

        }



    }

    IEnumerator CoronaVirus()
    {

        itemDescribe.gameObject.SetActive(true);
        string itemDesc = getRandomItem();
        //description.text = "You open the case and said\r\n" + itemDesc;
        description.text = itemDesc;
        Debug.Log(itemDesc);

        yield return new WaitForSeconds(2);



        rm.Health += HealthWoodFood[midIndex].x;
        rm.food += HealthWoodFood[midIndex].z;
        rm.sanity += SanityFiberFlint[midIndex].x;
        toolTip.gameObject.SetActive(false);
        suitcase = false;
        itemDescribe.gameObject.SetActive(false);
        Destroy(GameObject.FindWithTag("Suitcase"));
    }

}
