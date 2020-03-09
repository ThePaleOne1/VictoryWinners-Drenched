using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseScreen;

    public bool pauseActive;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseActive = false;

        pauseScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
        pauseActive = false;
        Debug.Log("game resumed");
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
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
}
