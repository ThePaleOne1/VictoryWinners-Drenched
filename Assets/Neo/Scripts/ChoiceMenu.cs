using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMenu : MonoBehaviour
{
    DialogPrompts instance;
    Dialogue dialogue;
    DialogueTrigger trigger;

    public Button choice01;
    public Button choice02;

    private bool isPressed01 = false;
    private bool isPressed02 = false;

    public void DisplayChoices()
    {
        choice01.gameObject.SetActive(true);
        choice01.gameObject.SetActive(true);

        choice01Identifier();
        choice02Identifier();
    }

    public void choice01Identifier()
    {
        choice01 = choice01.GetComponent<Button>();
        choice01.onClick.AddListener(TaskOnClick01);
    }

    public void TaskOnClick01()
    {
        isPressed01 = true;
        print("choice 1 picked");
    }

    public void choice02Identifier()
    {
        choice02 = choice02.GetComponent<Button>();
        choice02.onClick.AddListener(TaskOnClick02);
    }

    public void TaskOnClick02()
    {
        isPressed02 = true;
        print("choice 2 picked");
    }

    void Update()
    {
        if(isPressed01 == true)
        {
            choice01.gameObject.SetActive(false);
            choice02.gameObject.SetActive(false);

            isPressed01 = false;
            isPressed02 = false;
        }
        else if(isPressed02 == true)
        {
            choice01.gameObject.SetActive(false);
            choice02.gameObject.SetActive(false);

            isPressed01 = false;
            isPressed02 = false;
        }
    }
}
