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
<<<<<<< HEAD
=======

    [SerializeField]
    GameObject[] otherAgents;
    [SerializeField]
    float detectDistance = 10;
>>>>>>> master
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Wander();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete || agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            clock -= Time.deltaTime;
<<<<<<< HEAD
=======
            foreach (GameObject obj in otherAgents)
            {
                if (Vector3.Distance(transform.position, obj.transform.position) < detectDistance)
                {
                    agent.SetDestination(RandomNavSphere(obj.transform.position, detectDistance / 2, -1));
                    clock = Random.Range(0, 5);
                }
            }
>>>>>>> master
        }

        if (clock <= 0)
        {
            Wander();
        }
<<<<<<< HEAD
=======

        

>>>>>>> master
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
}
