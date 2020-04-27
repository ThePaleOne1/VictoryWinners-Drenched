using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;
    public float sanityDamage;
    public float attackSpeed;

    public float attackTimer;

    public float playerDamage;

    public bool ded;

    public Vector3[] HealthFoodSanity;

    public ResourceMeter statusStuff;
    public EnemySpawner spawner;

    int index;

    private void Start()
    {
        statusStuff = FindObjectOfType<ResourceMeter>();

        spawner = FindObjectOfType<EnemySpawner>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            ded = true;          
        }

        if(ded == true)
        {
            EnemyDrop();
            Destroy(this.gameObject);
            spawner.currentEnemySpawn -= 1;
            ded = false;
        }
    }

    void EnemyDrop()
    {
        statusStuff.Health += HealthFoodSanity[index].x;
        statusStuff.food += HealthFoodSanity[index].y;
        statusStuff.sanity += HealthFoodSanity[index].z;
    }



}
