using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject Controls;

    public GameObject Status;

    public GameObject Crafting;

    public Text daysAlive;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);

        LoadScore();
    }

    public void LoadScore()
    {
        GameData data = SaveSystem.LoadScore();

        daysAlive.text = "Longest Survived: " + data.daysAlive + " days";
    }

    public void newGame(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ClickBack()
    {
        mainMenu.SetActive(true);

        print("BACKTOMENU");
    }

    public void ClickQuit()
    {
        Application.Quit();

        print("see you next time...");
    }

    public void ClickControls()
    {
        Controls.SetActive(true);
        Status.SetActive(false);
        Crafting.SetActive(false);
    }

    public void ClickStatus()
    {
        Controls.SetActive(false);
        Status.SetActive(true);
        Crafting.SetActive(false);
    }

    public void ClickCrafting()
    {
        Controls.SetActive(false);
        Status.SetActive(false);
        Crafting.SetActive(true);
    }
}
