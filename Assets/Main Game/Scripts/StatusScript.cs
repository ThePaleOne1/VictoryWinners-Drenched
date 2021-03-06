﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxFood = 100;
    public float maxResource = 100;
    public float maxSanity = 100;

    //public float currentHealth;
    private float currentFood;
    private float currentSanity;

    public Slider healthSlider;
    public Slider foodSlider;
    public Slider woodSlider;
    public Slider fiberSlider;
    public Slider flintSlider;
    public Slider sanitySlider;

    //public Text healthText;
    //public Text foodText;
    //public Text sanityText;

    public Image healthIcon;
    public Image foodIcon;
    public Image sanityIcon;

    public Text healthNumber;   
    public Text foodNumber;
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showStatus();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            hideStatus();
        }
        
        updateStatus();
    }

    //set everything to tha H U and DDDDDDDDDDDDDDDDD
    public void setStatus()
    {
        StatusStuff.Health = maxHealth;
        currentFood = StatusStuff.food;
        currentSanity = StatusStuff.sanity;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        foodSlider.maxValue = maxFood;
        foodSlider.value = maxFood;

        sanitySlider.maxValue = maxSanity;
        sanitySlider.value = currentSanity;

        healthNumber.text = "" + StatusStuff.Health.ToString("f0");
        foodNumber.text = "" + currentFood.ToString("f0");
        sanityNumber.text = "" + currentSanity.ToString("f0");
    }
   
    //shows numbers on tab hold
    public void showStatus()
    {
        healthNumber.gameObject.SetActive(true);
        healthIcon.gameObject.SetActive(false);

        foodNumber.gameObject.SetActive(true);
        foodIcon.gameObject.SetActive(false);

        sanityNumber.gameObject.SetActive(true);
        sanityIcon.gameObject.SetActive(false);
    }

    //hides numbers on tab release
    public void hideStatus()
    {
        healthNumber.gameObject.SetActive(false);
        healthIcon.gameObject.SetActive(true);

        foodNumber.gameObject.SetActive(false);
        foodIcon.gameObject.SetActive(true);

        sanityNumber.gameObject.SetActive(false);
        sanityIcon.gameObject.SetActive(true);
    }

    //updates any changes to statuses
    public void updateStatus()
    {
        healthSlider.value = StatusStuff.Health;
        healthNumber.text = "" + StatusStuff.Health.ToString("f0");

        currentFood = StatusStuff.food;
        foodSlider.value = currentFood;
        foodNumber.text = "" + currentFood.ToString("f0");

        currentSanity = StatusStuff.sanity;
        sanitySlider.value = currentSanity;
        sanityNumber.text = "" + currentSanity.ToString("f0");
    }
}
