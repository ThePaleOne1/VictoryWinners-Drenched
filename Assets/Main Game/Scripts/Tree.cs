using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    
    public GameObject coconut;

    public int durability;

    [SerializeField]
    GameObject rotatePoint;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(2, 5);

        Player = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (durability <= 0)
        {
            transform.RotateAround(rotatePoint.transform.position, Player.transform.right,3);
        }

        if ((transform.rotation.eulerAngles.x > 90 && transform.rotation.eulerAngles.x < 270) || (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270))
        {
            Destroy(gameObject);
        }
    }
}
