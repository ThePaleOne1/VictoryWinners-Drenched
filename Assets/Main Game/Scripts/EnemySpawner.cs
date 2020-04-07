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

        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));

        if(currentEnemySpawn < maxEnemySpawn)
        {
            newEnemy = Instantiate(enemy, randomPosition, transform.rotation);
            currentEnemySpawn++;
        }
    }
}
