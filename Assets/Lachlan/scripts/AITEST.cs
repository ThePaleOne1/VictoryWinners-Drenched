using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITEST : MonoBehaviour
{
    NavMeshAgent agent;
    float clock;

    [SerializeField]
    float wandDistance;
    // Start is called before the first frame update

    [SerializeField]
    GameObject destination;
    [SerializeField]
    float HuddleTogetherDistance = 1;

    bool isDoingStuff;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Wander();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDoingStuff)
        {
            //if (agent.pathStatus == NavMeshPathStatus.PathComplete || agent.pathStatus == NavMeshPathStatus.PathInvalid)
            //{
                clock -= Time.deltaTime;
            //}

            if (clock <= 0)
            {
                Wander();
            }
        }

        //print(agent.pathStatus);

        destination.transform.position = agent.destination;

    }

    void Wander()
    {
        agent.SetDestination(RandomNavSphere(transform.position, wandDistance, -1));
        clock = Random.Range(0, 5);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Character") && CompareTag("Character"))
        {
            print("Character has met another character");
            agent.SetDestination(RandomNavSphere(col.transform.position, HuddleTogetherDistance, -1));
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Character") && CompareTag("Character"))
        {
            print("Character has met another character");
            agent.SetDestination(RandomNavSphere(col.transform.position, HuddleTogetherDistance, -1));
        }
    }

    private void OnTriggerStay(Collider col)
    {
        //if (col.CompareTag("Character") && CompareTag("Character"))
        //{
        //    print("Character has met another character");
        //    agent.SetDestination(RandomNavSphere(col.transform.position, HuddleTogetherDistance, -1));
        //}


        if (col.CompareTag("Threat") && CompareTag("Character"))
        {
            //print("character has met a threat");
            agent.SetDestination(transform.position + (transform.position - col.transform.position));

        }
    }

}
