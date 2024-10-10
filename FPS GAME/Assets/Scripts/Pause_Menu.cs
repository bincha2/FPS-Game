using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        //unlock the cursor when paused so i can interact with the pause menu buttons
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        //lock the cursor back so it dissapears when unpaused
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }
    public void QuitGame()
    {
        Application.Quit();

        //added this so that i can see if it quits in editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}