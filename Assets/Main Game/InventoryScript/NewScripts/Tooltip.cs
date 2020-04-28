using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text TooltipText;
    
    void Start()
    {
        TooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    
}
