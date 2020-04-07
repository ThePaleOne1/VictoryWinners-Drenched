using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    int durability;
    public float fiberAmmount = 5;

    public void BushHit()
    {
        --durability;
    }

    private void Update()
    {
        if (durability < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        durability = Random.Range(1, 2);
        transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
    }
}
