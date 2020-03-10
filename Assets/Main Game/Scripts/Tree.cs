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


    public bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        durability = Random.Range(3, 5);

        Player = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (isHit)
        {
            Invoke("Shake1", 0.5f);
            
            isHit = false;
        }


        if (durability <= 0)
        {
            transform.RotateAround(rotatePoint.transform.position, Player.transform.right,1);
        }

        if ((transform.rotation.eulerAngles.x > 90 && transform.rotation.eulerAngles.x < 270) || (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270))
        {
            Destroy(gameObject);
        }
    }




    void Shake1()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, 2);

        Invoke("Shake2", 0.1f);
    }

    void Shake2()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, 2);

        Invoke("Shake3", 0.1f);
    }

    void Shake3()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, -2);

        Invoke("Shake4", 0.1f);
    }

    void Shake4()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, -2);

        Invoke("Shake5", 0.1f);
    }

    void Shake5()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, -2);

        Invoke("Shake6", 0.1f);
    }

    void Shake6()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, 2);

        Invoke("Shake7", 0.05f);
    }

    void Shake7()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, 2);

        Invoke("Shake8", 0.05f);
    }

    void Shake8()
    {
        transform.RotateAround(rotatePoint.transform.position, Player.transform.right, -2);


    }
}
