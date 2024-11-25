using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public static Player_Health instance;

    public int maxHealth;

    public int currHealth;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;

        //adjust the slider and hp text to the curr / max health of the player at the start
        HP_Bar.instance.HPslider.maxValue = maxHealth;
        HP_Bar.instance.HPslider.value = currHealth;
        HP_Bar.instance.HPtext.text = currHealth + " / " + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakePlayerDMG(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            gameObject.SetActive(false); // player dies

            currHealth = 0; // hp is 0

            GameManager.instance.PlayerDeath(); // respawn / death screen
        }

        //update the slider and text to correespond player hp
        HP_Bar.instance.HPslider.value = currHealth;
        HP_Bar.instance.HPtext.text = currHealth + " / " + maxHealth;
    }

    public void PickupHealth(int heal) // function for when plauer picks up hp
    {
        currHealth += heal;

        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }

        //update the slider and text to correespond player hp
        HP_Bar.instance.HPslider.value = currHealth;
        HP_Bar.instance.HPtext.text = currHealth + " / " + maxHealth;
    }
}
