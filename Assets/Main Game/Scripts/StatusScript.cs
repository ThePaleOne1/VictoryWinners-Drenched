using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxFood = 100;
    public float maxResource = 100;
    public float maxSanity = 100;

    private float currentResource;
    public float currentHealth;
    private float currentFood;
    private float currentSanity;

    public float drainHealth;

    public Slider healthSlider;
    public Slider foodSlider;
    public Slider resourceSlider;
    public Slider sanitySlider;

    public Text healthNumber;
    public Text foodNumber;
    public Text resourceNumber;
    public Text sanityNumber;

    [SerializeField] private ResourceMeter StatusStuff;
    
    // Start is called before the first frame update
    void Start()
    {
        setStatus();

        hideStatus();
    }

    // Update is called once per frame
    void Update()
    {
        //if(currentHealth > 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        currentHealth -= 10;

        //        updateStatus();

        //        Debug.Log("ouchies");
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showStatus();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            hideStatus();
        }

        drainStatus();
        updateStatus();
    }

    //set everything to tha H U and DDDDDDDDDDDDDDDDD
    public void setStatus()
    {
        currentHealth = maxHealth;
        currentFood = StatusStuff.food;
        currentResource = StatusStuff.wood;
        currentSanity = StatusStuff.sanity;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        foodSlider.maxValue = maxFood;
        foodSlider.value = maxFood;

        resourceSlider.maxValue = maxResource;
        resourceSlider.value = currentResource;

        sanitySlider.maxValue = maxSanity;
        sanitySlider.value = currentSanity;

        healthNumber.text = "" + currentHealth.ToString("f0");
        foodNumber.text = "" + currentFood.ToString("f0");
        resourceNumber.text = "" + currentResource.ToString("f0");
        sanityNumber.text = "" + currentSanity.ToString("f0");
    }

    public void drainStatus()
    {
        if (currentFood <= 0)
        {
            if (currentHealth > 5)
            {
                currentHealth -= drainHealth * Time.deltaTime;
            }
        }
    }

   
    //shows numbers on tab hold
    public void showStatus()
    {
        healthNumber.gameObject.SetActive(true);

        foodNumber.gameObject.SetActive(true);

        resourceNumber.gameObject.SetActive(true);

        sanityNumber.gameObject.SetActive(true);
    }

    //hides numbers on tab release
    public void hideStatus()
    {
        healthNumber.gameObject.SetActive(false);

        foodNumber.gameObject.SetActive(false);

        resourceNumber.gameObject.SetActive(false);

        sanityNumber.gameObject.SetActive(false);
    }

    //updates any changes to statuses
    public void updateStatus()
    {
        healthSlider.value = currentHealth;
        healthNumber.text = "" + currentHealth.ToString("f0");

        currentFood = StatusStuff.food;
        foodSlider.value = currentFood;
        foodNumber.text = "" + currentFood.ToString("f0");

        currentResource = StatusStuff.wood;
        resourceSlider.value = currentResource;
        resourceNumber.text = "" + currentResource.ToString("f0");

        currentSanity = StatusStuff.sanity;
        sanitySlider.value = currentSanity;
        sanityNumber.text = "" + currentSanity.ToString("f0");
    }
}
