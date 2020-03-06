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

    public float drainHealth;

    public float drainFood;

    public Slider healthSlider;

    public Slider foodSlider;

    public Slider resourceSlider;

    public Text healthNumber;

    public Text foodNumber;

    public Text resourceNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        setStatus();

        hideStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentHealth -= 10;

                updateStatus();

                Debug.Log("ouchies");
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showStatus();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            hideStatus();
        }

        drainStatus();
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

        healthNumber.text = "" + currentHealth.ToString("f0");

        foodNumber.text = "" + currentFood.ToString("f0");

        resourceNumber.text = "" + currentResource.ToString("f0");
    }

    public void drainStatus()
    {
        if (currentFood <= 0)
        {
            if(currentHealth > 5)
            {
                currentHealth -= drainHealth * Time.deltaTime;

                updateStatus();
            }      
        }

        if (currentFood > 0)
        {
            currentFood -= drainFood * Time.deltaTime;

            updateStatus();
        }
    }

    public void showStatus()
    {
        healthNumber.gameObject.SetActive(true);

        foodNumber.gameObject.SetActive(true);

        resourceNumber.gameObject.SetActive(true);
    }

    public void hideStatus()
    {
        healthNumber.gameObject.SetActive(false);

        foodNumber.gameObject.SetActive(false);

        resourceNumber.gameObject.SetActive(false);
    }

    public void updateStatus()
    {
        healthSlider.value = currentHealth;

        healthNumber.text = "" + currentHealth.ToString("f0");

        foodSlider.value = currentFood;

        foodNumber.text = "" + currentFood.ToString("f0");
    }
}
