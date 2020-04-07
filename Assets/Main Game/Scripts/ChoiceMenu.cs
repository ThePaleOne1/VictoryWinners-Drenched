using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMenu : MonoBehaviour
{
    DialogPrompts instance;
    Dialogue dialogue;
    DialogueTrigger trigger;

    public Button choiceButton;

    private bool isPressed01 = false;
    private bool isPressed02 = false;

    public void DisplayChoices()
    {
        choiceButton.gameObject.SetActive(true);
        

        choice01Identifier();
        choice02Identifier();
    }

    public void choice01Identifier()
    {
        choiceButton = choiceButton.GetComponent<Button>();
        
        choiceButton.onClick.AddListener(TaskOnClick01);
    }

    public void TaskOnClick01()
    {
        isPressed01 = true;
        instance.DialogueBox.SetActive(true);
        instance.dialogueText.text = "you picked option 1";
        print("choice 1 picked");
    }

    public void choice02Identifier()
    {
       
    }

    public void TaskOnClick02()
    {
        isPressed02 = true;
        instance.DialogueBox.SetActive(true);
        instance.dialogueText.text = "you picked option 2";
        print("choice 2 picked");
    }

    void Update()
    {
        if(isPressed01 == true)
        {
            choiceButton.gameObject.SetActive(false);
           

            isPressed01 = false;
            isPressed02 = false;
        }
        else if(isPressed02 == true)
        {
            choiceButton.gameObject.SetActive(false);
            

            isPressed01 = false;
            isPressed02 = false;
        }
    }
}
