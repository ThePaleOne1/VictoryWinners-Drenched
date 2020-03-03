using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject playMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);

        playMenu.SetActive(false);
    }

    public void ClickPlay()
    {
        mainMenu.SetActive(false);

        playMenu.SetActive(true);

        print("play");
    }

    public void ClickBack()
    {
        mainMenu.SetActive(true);

        playMenu.SetActive(false);

        print("BACKTOMENU");
    }

    public void ClickQuit()
    {
        Application.Quit();

        print("see you next time...");
    }

    
}
