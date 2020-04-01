using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemySpawn;

    public int currentEnemySpawn;

    public GameObject enemy;

    public GameObject newEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        currentEnemySpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnNewEnemy());       

        if(currentEnemySpawn == maxEnemySpawn)
        {
            StopCoroutine(SpawnNewEnemy());
        }
        
    }

    IEnumerator SpawnNewEnemy()
    {
        yield return new WaitForSeconds(5);       

        if(currentEnemySpawn < maxEnemySpawn)
        {
            newEnemy = Instantiate(enemy, transform.position, transform.rotation);
            currentEnemySpawn++;
        }
    }
}
