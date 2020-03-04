using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public float maxHealth = 100;

    public float maxFood = 100;

    public float maxResource = 100;

    public float currentHealth;

    public float currentFood;

    public float currentResource;

    public Slider healthSlider;

    public Slider foodSlider;

    public Slider resourceSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        setStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStatus()
    {
        currentHealth = maxHealth;

        currentFood = maxFood;

        currentResource = maxResource;

        healthSlider.maxValue = maxHealth;

        healthSlider.value = maxHealth;

        foodSlider.maxValue = maxFood;

        foodSlider.value = maxFood;

        resourceSlider.maxValue = maxResource;

        resourceSlider.value = maxResource;
    }
}
