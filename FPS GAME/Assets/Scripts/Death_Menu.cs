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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MainMenu() // return to the main menu of game
    {
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
