using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChoiceEvent : UnityEvent<DialogueChoices> { }

public class DialogPrompts : MonoBehaviour
{
    private Queue<string> sentences;

    public Text dialogueText;

    public GameObject continueText;

    public GameObject DialogueBox;

    private float TypingSpeed = 0.001f;

    public DialogueChoices choices;

    public DialogueTrigger trigger;

    //public Dialogue dialogue;

    private bool dialogueStart;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        continueText = GameObject.Find("Continue"); 
    }

    public void ChangeDialogue(Dialogue newDialogue)
    {
        dialogueStart = false;
        trigger.dialogue = newDialogue;
        trigger.TriggerDialogue();
    }

    public void StartDialog(Dialogue dialogue)
    {
        print("Dialogue starts");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueStart = true;
        DisplayNextSentence();
        continueText.SetActive(false);
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //print(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNewDialogue()
    {
        if (choices != null)
        {
            //ChoiceEvent.Invoke(choices);
        }
        else if (trigger.newDialogue != null)
        {
            ChangeDialogue(trigger.newDialogue);
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(TypingSpeed);

            continueText.SetActive(true);
        }
    }

    void EndDialogue()
    {
        dialogueStart = false;
        DialogueBox.SetActive(false);
        print("Fin");
        dialogueText.text = "";
    }
}
