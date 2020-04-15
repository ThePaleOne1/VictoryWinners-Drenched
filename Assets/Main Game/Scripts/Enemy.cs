using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;
    public float attackSpeed;

    public float attackTimer;

    public float playerDamage;

    public bool ded;

    public Vector3[] HealthFoodSanity;
    public Vector3[] WoodFiberFlint;

    public ResourceMeter statusStuff;
    public EnemySpawner spawn;

    int index;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            ded = true;
            StartCoroutine(EnemyDrop());
        }
    }

    IEnumerator EnemyDrop()
    {
        yield return new WaitForSeconds(0);

        statusStuff.Health += HealthFoodSanity[index].x;
        statusStuff.food += HealthFoodSanity[index].y;
        statusStuff.sanity += HealthFoodSanity[index].z;

        statusStuff.wood += WoodFiberFlint[index].x;
        statusStuff.fiber += WoodFiberFlint[index].y;
        statusStuff.flint += WoodFiberFlint[index].z;
    }



}
