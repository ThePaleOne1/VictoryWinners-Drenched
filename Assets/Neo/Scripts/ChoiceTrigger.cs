﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTrigger : MonoBehaviour
{
    public Choice choices;
    public Text choiceText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    //public void Change(Choice _choices)
    //{
    //    RemoveChoices();
    //    choices = _choices;
    //    gameObject.SetActive(true);
    //    Intialize();
    //}

    //public void Hide(Dialogue dialogue)
    //{
    //    RemoveChoices();
    //    gameObject.SetActive(false);
    //}

    //public void RemoveChoices()
    //{
    //    foreach (ChoiceController c in choiceControllers)
    //    {
    //        Destroy(c.gameObject);

    //        choiceControllers.Clear();
    //    }
    //}

    //private void Intialize()
    //{
    //    choiceText.text = choices.text;

    //    for(int index = 0; index < choices.choice.Length; index++)
    //    {
    //        ChoiceControllers c = ChoiceController.AddChoiceButton(choiceButton, DialogueChoices.choicetext[index], index);
    //        choiceControllers.Add(c);
    //    }

    //    choiceButton.gameObject.SetActive(true);
    //}
}