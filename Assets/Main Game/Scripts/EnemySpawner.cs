using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemySpawn;

    public int currentEnemySpawn;

    public float currentSpawnTime;

    public float maxSpawnTime;

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
        yield return new WaitForSeconds(0);

        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f) + transform.position.x, transform.position.y, Random.Range(-10f, 10f) + transform.position.z);

        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-180f, 180f), 0);

        if(currentEnemySpawn < maxEnemySpawn)
        {
            currentSpawnTime -= 1 * Time.deltaTime;

            if (currentSpawnTime <= 0)
            {
                newEnemy = Instantiate(enemy, randomPosition, randomRotation);
                currentEnemySpawn += 1;
                currentSpawnTime = maxSpawnTime;
            }           
        }
    }
}
