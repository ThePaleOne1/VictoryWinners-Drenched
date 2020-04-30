using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunGoku : MonoBehaviour
{
    public float rotateSpeed;

    public float angleZ;

    public bool dayTime;

    public float drainSanity;

    public bool daySurvived;

    public int daysAlive;

    public int mostDaysAlive;

    public GameObject dayNNite;

    PlayerController controller;

    [SerializeField] ResourceMeter statusStuff;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = PlayerManager.instance.player.GetComponent<PlayerController>();

        GameData data = SaveSystem.LoadScore();

        mostDaysAlive = data.daysAlive;
    }

    // Update is called once per frame
    void Update()
    {
       transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
       transform.LookAt(Vector3.zero);

       angleZ = dayNNite.transform.eulerAngles.z;

        if (controller.Dead)
        {
            SaveScore();
        }   

       DayCycle();
    }

    void SaveScore()
    {        
       if (daysAlive >= mostDaysAlive)
       {
          SaveSystem.SaveScore(this);
       }             
    }

    void DayCycle()
    {
        NightTime();
        DayTime();

        if (angleZ > 120)
        {
            dayTime = false;
        }

        if (angleZ < 120)
        {
            dayTime = true;
        }     
    }

    void NightTime()
    {
        if (!dayTime)
        {
            if (daySurvived)
            {
                if (!controller.Dead)
                {
                    ++daysAlive;

                    daySurvived = false;
                }               
            }
        }       
    }

    void DayTime()
    {
        if (dayTime)
        {
            //Debug.Log("IT'S NIGHT");

            daySurvived = true;

            statusStuff.sanity -= drainSanity * Time.deltaTime;
        }
    }   
}
