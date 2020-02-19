using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public float timeLeft = 10;

    public bool countdownEnd;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(countdownEnd = true)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                Debug.Log(timeLeft);
            }
            if(timeLeft == 0)
            {
                countdownEnd = false;
            }
        }

        if (countdownEnd = false)
        {
            TriggerDialogue();
            
            countdownEnd = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogPrompts>().StartDialog(dialogue);
    }
}
