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

    public void GenerateTooltip(Item item)
    {
        string statText = "";
        foreach (var stat in item.stats)
        {
            statText += stat.Key.ToString() + ": " + stat.Value + "\n";
        }

        string tooltip = string.Format("<b>{0}</b>\n{1}", item.title, item.description);
        TooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
