using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Death_Menu : MonoBehaviour
{
    public string main_menu;

    public static Death_Menu instance;

    public TextMeshProUGUI finalKillCountText;

     void Start()
    {
        // Display the kill count when death menu loads
        if (finalKillCountText != null)
        {
            int finalKills = PlayerPrefs.GetInt("KillCount", 0);
            finalKillCountText.text = "Final Kill Count: " + finalKills;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MainMenu() // return to the main menu of game
    {
        PlayerPrefs.SetInt("KillCount", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(main_menu);
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
