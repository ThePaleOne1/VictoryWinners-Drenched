﻿using System.Collections;
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

    Transform target;

    NavMeshAgent agent;

    [SerializeField] ResourceMeter statusStuff;

    [SerializeField] Enemy theEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        startingPosition = transform.position;

        playerDetected = false;

        positionSet = false;

        waitTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        float wanderDistance = Vector3.Distance(finalPosition, transform.position);

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
                    EnemyAttack();
                }
            }
            else
            {
                withinAttackRange = false;
            }
        }
        else
        {
            playerDetected = false;
        }

        if(playerDetected == false)
        {
            if (waitTime <= 0)
            {
                if (positionSet == true)
                {
                    Debug.Log("wandering to position");

                    agent.SetDestination(finalPosition);

                    if (wanderDistance == agent.stoppingDistance)
                    {
                        Debug.Log("wander destination reached");

                        waitTime -= 1 * Time.deltaTime;

                        positionSet = false;
                    }
                }
            }
            else if (waitTime > 0)
            {
                if (positionSet == false)
                {
                    RoamingData();
                }
            }
        }
        
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

            theEnemy.attackTimer = 5f;

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

        Debug.Log("Poisiton found");

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
