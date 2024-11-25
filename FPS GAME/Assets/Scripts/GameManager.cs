using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float DeathTimer = 1;
    public string DeathMenu = "DeathMenu";

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDeath()
    {
        // when player dies from player_health.cs, call death scene
        StartCoroutine(PlayerDeathCoroutine());
    }

    public IEnumerator PlayerDeathCoroutine()
    {
        yield return new WaitForSeconds(DeathTimer);
        SceneManager.LoadScene(DeathMenu); // respawn
        Cursor.lockState = CursorLockMode.None;
    }
}
