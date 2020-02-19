using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPrompts : MonoBehaviour
{
    private Queue<string> sentences;

    public Text dialogueText;

    public GameObject continueText;

    public GameObject DialogueBox;

    private float TypingSpeed = 0.001f;

    public ChoiceMenu callChoices;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        continueText = GameObject.Find("Continue");

        callChoices.choice01.gameObject.SetActive(false);
        callChoices.choice02.gameObject.SetActive(false);
    }

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
            callChoices.choice01.gameObject.SetActive(true);
            callChoices.choice02.gameObject.SetActive(true);
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //print(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
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
        print("Fin");
        dialogueText.text = "";
    }
}
