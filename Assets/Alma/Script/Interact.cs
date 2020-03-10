using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.Linq;

public class Interact : MonoBehaviour
{

    public float displayDur = 3f;

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
    public Text description;

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
            middle[midIndex] + " it's " +
            ending[endIndex];

        return itemWording;
    }




    private void Start()
    {
        toolTip.gameObject.SetActive(false);
        itemDescribe.gameObject.SetActive(false);

        //effects.Add(new Vector3(health, food, wood), new Vector3(sanity, 0, 0));

        

    }

    private void Update()
    {
        if (suitcase && Input.GetKeyDown(KeyCode.E))
        {
            CoronaVirus();

           

        }

        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Suitcase"))
        {
            toolTip.gameObject.SetActive(true);
            suitcase = true;

        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Suitcase"))
        {
            toolTip.gameObject.SetActive(false);
            suitcase = false;
            itemDescribe.gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("Suitcase"));
        }

        

    }

    public void CoronaVirus()
    {           
             
        itemDescribe.gameObject.SetActive(true);
        string itemDesc = getRandomItem();
        description.text = "You open the case and said\r\n" + itemDesc;
        Debug.Log(itemDesc);

        rm.Health += HealthWoodFood[midIndex].x;
        rm.wood += HealthWoodFood[midIndex].y;
        rm.food += HealthWoodFood[midIndex].z;
        rm.sanity += SanityFiberFlint[midIndex].x;
        rm.fiber += SanityFiberFlint[midIndex].y;
        rm.flint += SanityFiberFlint[midIndex].z;
    }

}
