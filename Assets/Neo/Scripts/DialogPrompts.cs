using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChoiceEvents : UnityEvent<DialogueChoices> { }

public class DialogPrompts : MonoBehaviour
{
    private Queue<string> sentences;

    public Text dialogueText;

    public GameObject continueText;

    public GameObject DialogueBox;

    private float TypingSpeed = 0.001f;

    public ChoiceMenu callChoices;

    public DialogueChoices choices;

    private bool dialogueStart;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        continueText = GameObject.Find("Continue");

        callChoices.choiceButton.gameObject.SetActive(false);
       
    }

    //public void ChangeDialogue(Dialogue newDialogue)
    //{
    //    dialogueStart = false;
    //    sentences = newDialogue;
    //    StartDialog(); 
    //}

    public void StartDialog(Dialogue dialogue)
    {
        print("Dialogue starts");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

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

    //public void DisplayNewDialogue()
    //{
    //    if (choices.choicetext != null)
    //    {
    //        ChoiceEvents.Invoke(DialogPrompts.choices);
    //    }
    //    else if (DialogPrompts.ChangeDialogue != null)
    //    {
    //        ChangeDialogue(dialogueStart.newDialogue);
    //    }
    //    else
    //    {
    //        EndDialogue();
    //    }
    //}

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
