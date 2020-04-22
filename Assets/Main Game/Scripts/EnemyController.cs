using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float aggroRadius = 10f;
    public float roamRadius = 50f;
    public float attackRadius = 3f;

    private bool playerDetected;

    private bool positionReturn;

    public bool positionSet;

    public bool withinAttackRange;

    private Vector3 finalPosition;

    private Vector3 startingPosition;

    public float waitTime;

    private Rigidbody rigidbody;

    Transform target;   

    NavMeshAgent agent;

    [SerializeField] ResourceMeter statusStuff;

    [SerializeField] Enemy theEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        rigidbody = GetComponent<Rigidbody>();

        statusStuff = FindObjectOfType<ResourceMeter>();

        theEnemy = FindObjectOfType<Enemy>();

        startingPosition = transform.position;

        positionSet = false;

        waitTime = 5f;

        playerDetected = false;      
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        Vector3 tarDir = target.position - transform.position;

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
                withinAttackRange = true;

                if (withinAttackRange)
                {
                    agent.isStopped = true;
                    EnemyAttack();
                }
            }
            else
            {
                agent.isStopped = false;
                withinAttackRange = false;
            }
        }
        else
        {
            playerDetected = false;
        }

        if(playerDetected == false)
        {
            if (positionSet == true)
            {
                //Debug.Log("wandering to position");

                agent.SetDestination(finalPosition);

                waitTime += 1 * Time.deltaTime;
            }

            if (waitTime >= Random.Range(1f, 5f))
            {
                positionSet = false;

                if (positionSet == false)
                {
                    RoamingData();
                }
            }

         
        }
        //Debug.Log(wanderDistance); 
    }

    void EnemyAttack()
    { 
        if (theEnemy.attackTimer > 0)
        {
            theEnemy.attackTimer -= theEnemy.attackSpeed * Time.deltaTime;                  
        }
        else if (theEnemy.attackTimer <= 0)
        {
            if (statusStuff.Health > 0)
            {
                statusStuff.Health -= theEnemy.attackDamage;
            }

            theEnemy.attackTimer = 10f;

            withinAttackRange = false;
        }
    }
       

    void RoamingData()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;

        randomDirection += transform.position;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);

        finalPosition = hit.position;

        //Debug.Log("Position found");

        positionSet = true;

        waitTime = 0f;        
    }

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
