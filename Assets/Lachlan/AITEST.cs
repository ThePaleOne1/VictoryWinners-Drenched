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
        }

        if (clock <= 0)
        {
            Wander();
        }
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
