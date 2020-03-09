using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMeter : MonoBehaviour
{
    public float wood;
    public float food;
    public float sanity;

    public float drainFood;

    [SerializeField] StatusScript statusHUD;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        drainStatus();

        //we can remove this later, but fucking hell 
        //its annoying to playtest the game while the mouse moves offscreen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    void drainStatus()
    {
        if (food > 0)
        {
            food -= drainFood * Time.deltaTime;
        }
    }
}
