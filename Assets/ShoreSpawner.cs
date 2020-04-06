using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoreSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject SpawnObject;

    [SerializeField] //use this to spawn items above the actual spawner if needed
    Vector3 spawnOffset = new Vector3(0, 0, 0);

    bool hasSpawned = false;
    private void OnTriggerEnter(Collider col)
    {
        print(col.name);
        if (col.tag == "Water"&& hasSpawned == false)
        {
            print("spawned something");
            hasSpawned = true;
            Instantiate(SpawnObject,transform.position + spawnOffset,transform.rotation);
        }
    }
}
