using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;

    NavMeshAgent agent;

    [SerializeField] ResourceMeter statusStuff;
    
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        statusStuff.Health -= 10;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
    }

    void OnGizmosSeleced()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
