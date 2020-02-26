using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class DialogueChangeEvent : UnityEvent<Dialogue> { }
public class ChoiceController : MonoBehaviour
{
    public Choice choices;
    public DialogueChangeEvent dialogueChangeEvent;

    public static ChoiceController AddChoiceButton(Button choiceButton, Choice choices, int index)
    {
        int buttonSpacing = -40;

        Button button = Instantiate(choiceButton);

        button.transform.SetParent(choiceButton.transform.parent);
        button.transform.localScale = Vector3.one;
        button.transform.localPosition = new Vector3(0, index * buttonSpacing, 0);
        button.name = "Choice " + (index + 1);
        button.gameObject.SetActive(true);

        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.choices = choices;
        return choiceController;
    }

    private void Start()
    {
        if(dialogueChangeEvent == null)
        {
            dialogueChangeEvent = new DialogueChangeEvent();

            GetComponent<Button>().GetComponentInChildren<Text>().text = choices.text;
        }
    }

    public void MakeChoice()
    {
        dialogueChangeEvent.Invoke(choices.dialogue);
    }
}
