using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float aggroRadius = 10f;
    public float roamRadius = 50f;
    public float attackRadius = 3f;

    public float lookAngle = 45f;

    private bool playerDetected;

    private bool positionSet;

    private Vector3 startingPosition;

    Transform target;

    NavMeshAgent agent;

    [SerializeField] ResourceMeter statusStuff;
    
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        startingPosition = transform.position;

        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        Vector3 tarDir = target.position - transform.position;

        float angle = Vector3.Angle(tarDir, transform.forward);


        if (distance <= aggroRadius)
        {
            agent.SetDestination(target.position);

            playerDetected = true;

            Debug.Log("detected");

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }

            
            if (distance <= attackRadius)
            {
                statusStuff.PlayerDamage();
            }    
        }

        if(distance >= aggroRadius)
        {
            positionSet = true;

            ReturnToStart();
            playerDetected = false;
        }

        //if (angle < lookAngle)
        //{
            
        //}

        RoamingData();
    }

    void ReturnToStart()
    {
        if(positionSet == true)
        {
            agent.destination = startingPosition;
            positionSet = false;
        }
    }
       

    void RoamingData()
    {
        if(playerDetected == false)
        {
            if(positionSet == false)
            {
                Vector3 randomDirection = Random.insideUnitSphere * roamRadius;

                randomDirection += transform.position;

                NavMeshHit hit;

                NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);

                Vector3 finalPosition = hit.position;

                agent.destination = finalPosition;
            }       
        } 
    }

    //void AttackTarget()
    //{

    //}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, aggroRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, roamRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
