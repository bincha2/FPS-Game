using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public float DeathTimer = 3f;

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
        // StartCoroutine(DeathCountdown()); // when player dies from player_health.cs, call deathcountdown
        StartCoroutine(PlayerDeathCoroutine());
    }

    public IEnumerator PlayerDeathCoroutine()
    {
        yield return new WaitForSeconds(DeathTimer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // respawn
    }
}
