﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCursor : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Cursor.visible = false;
        }
    }


}
