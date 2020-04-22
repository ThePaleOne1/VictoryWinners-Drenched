using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    bool hasAwoken = false;
    Animator anim;

    [SerializeField] GameObject Canvas;
    [SerializeField] Text NpcName;
    [SerializeField] Text NpcDialogue;
    [SerializeField] GameObject choicesPanel;
    [SerializeField] Text followStay;
    [SerializeField] Text ePrompt;
    public string[] Dialogue;
    [SerializeField] int defaultDialogue;
    [SerializeField] float TypingSpeed;
    
    
    bool isTypling = false;

    int whatSentenceAmIOn;

    bool hasChoice;

    [SerializeField] GameObject player;
    bool isFollowing = false;
    [SerializeField] float followDistance;
    bool isScavenging = false;

    bool interactCooldown = false;

    NavMeshAgent navAgent;

    [SerializeField] int followResponse;
    [SerializeField] int goAwayResponse;
    [SerializeField] int goodbyeResponse;
    [SerializeField] int tradeRespones;
    [SerializeField] int scavengeStartResponse;
    [SerializeField] int scavengeMinResponse;
    [SerializeField] int scavengeEndResponse;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Canvas.SetActive(false);
        navAgent = GetComponent<NavMeshAgent>();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (choicesPanel.activeSelf)
        {
            ePrompt.enabled = false;

            string number = Input.inputString;
            switch (number)
            {
                case "1":
                    print("choose to follow/go away");
                    isFollowing = !isFollowing;
                    if (!isFollowing)
                    {
                        whatSentenceAmIOn = goAwayResponse;
                    }
                    else
                    {
                        whatSentenceAmIOn = followResponse;
                    }
                    StartCoroutine(TypeSentence(Dialogue[whatSentenceAmIOn]));
                    hasChoice = false;
                    break;

                case "2":
                    print("choose to scavenge");
                    whatSentenceAmIOn = scavengeStartResponse;
                    StartCoroutine(TypeSentence(Dialogue[whatSentenceAmIOn]));
                    hasChoice = false;
                    break;

                case "3":
                    print("choose to trade");
                    whatSentenceAmIOn = tradeRespones;
                    StartCoroutine(TypeSentence(Dialogue[whatSentenceAmIOn]));
                    hasChoice = false;
                    break;

                case "4":
                    print("choose to leave the conversation");
                    whatSentenceAmIOn = goodbyeResponse;
                    StartCoroutine(TypeSentence(Dialogue[whatSentenceAmIOn]));
                    hasChoice = false;
                    break;
            }
                
        }
        else
        {
            ePrompt.enabled = true;
        }

        if (isFollowing)
        {
            followStay.text = "[1] Go Away";

            if (Vector3.Distance(transform.position, player.transform.position) > followDistance)
            {
                navAgent.SetDestination(player.transform.position + (Random.onUnitSphere * followDistance));
            }
        }
        else
        {
            followStay.text = "[1] Follow Me";
        }



        if (hasChoice && !isTypling)
        {
            choicesPanel.SetActive(true);
        }
        else if(!hasChoice)
        {
            choicesPanel.SetActive(false);
        }

        float velocity = navAgent.velocity.magnitude;
        if (velocity > 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (!interactCooldown)
            {
                interactCooldown = true;
                Interact();
                Invoke("CooldownReset", 0.2f);
            }
            
        }
    }

    void Interact()
    {
        if (!hasAwoken)
        {
            anim.SetTrigger("GetUp");
        }
        else
        {
            if (Canvas.activeSelf)
            {
                if (isTypling)
                {
                    print("skipping print");
                    SkipTextPrint();
                }
                else
                {
                    print("going to next sentence");
                    NextSentence();
                }
            }
            else
            {
                print("initiating interaction");
                hasChoice = true;
                whatSentenceAmIOn = defaultDialogue;
                StartInteracting();
            }
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Canvas.SetActive(false);
        }
    }

    void CooldownReset()
    {
        interactCooldown = false;
    }

    void TalkOnAwake()
    {
        hasAwoken = true;
        whatSentenceAmIOn = 0;
        StartInteracting();

    }

    void StartInteracting()
    {
        Canvas.SetActive(true);
        NpcName.text = this.name;
        StartCoroutine(TypeSentence(Dialogue[whatSentenceAmIOn]));
    }

    void StopInteracting()
    {
        Canvas.SetActive(false);
        StopAllCoroutines();
    }

    void NextSentence()
    {
        if (!hasChoice) 
        {
            if (Dialogue[whatSentenceAmIOn + 1] == "end")
            {
                StopInteracting();
                return;
            }

            isTypling = true;
            ++whatSentenceAmIOn;
            StartCoroutine(TypeSentence(Dialogue[whatSentenceAmIOn]));
        }
    }

    void SkipTextPrint()
    {
        StopAllCoroutines();
        isTypling = false;
        NpcDialogue.text = Dialogue[whatSentenceAmIOn];
    }
    IEnumerator TypeSentence(string sentence)
    {
        isTypling = true;
        NpcDialogue.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            if (isTypling)
            {
                NpcDialogue.text += letter;
                yield return new WaitForSeconds(TypingSpeed);
            }
        }
        
        isTypling = false;
        if (hasChoice)
        {
            choicesPanel.SetActive(true);
        }
    }
}
