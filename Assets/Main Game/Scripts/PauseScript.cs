using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseScreen;

    public GameObject gameOverScreen;

    GameObject player;

    PlayerController controller;

    public bool pauseActive;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseActive = false;

        pauseScreen.SetActive(false);

        gameOverScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        player = PlayerManager.instance.player;

        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseActive)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Pause();
            }
        }

        if (controller.Dead)
        {
            GameOver();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        controller.mouseLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
        pauseActive = false;
        Debug.Log("game resumed");
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        controller.mouseLook = false;
        Cursor.lockState = CursorLockMode.None;
        pauseScreen.SetActive(true);
        pauseActive = true;
        Debug.Log("game paused");
    }

    public void QuitLevel(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        controller.mouseLook = false;
        gameOverScreen.SetActive(true);
    }
}
