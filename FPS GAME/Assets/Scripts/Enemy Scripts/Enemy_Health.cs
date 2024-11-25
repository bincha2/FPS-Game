using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDMG(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject); //destroy enemy once health is depleted
            HP_Bar.instance.killCount += 1;
            HP_Bar.instance.KillCounter.text = "Kill Count: " + HP_Bar.instance.killCount;
        }
    }
}
