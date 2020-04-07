using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool newDay;

    public GameObject button;

    public DialogueChoices choices;

    public Dialogue newDialogue;

    void Start()
    {
        newDay = true;
    }
    
    void Update()
    {
        if (newDay)
        {
            TriggerDialogue();
            newDay = false;
        } 
    }

    public void TriggerDialogue()
    {
        HideButton();
        FindObjectOfType<DialogPrompts>().StartDialog(dialogue);
    }

    public void HideButton()
    {
        button.SetActive(false);
    }
}
