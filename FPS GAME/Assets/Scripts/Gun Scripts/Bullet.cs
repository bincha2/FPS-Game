using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; // bullet speed
    public float lifetime; // liftetime of bullet
    private Rigidbody rb;

    public int damage; //dnmg of bullet

    public bool dmgEnemy;
    public bool dmgPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, lifetime); // Destroy after lifetime
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && dmgEnemy) // if enemy
        {
            other.gameObject.GetComponent<Enemy_Health>().TakeDMG(damage);
        }
        if (other.gameObject.tag == "Player" && dmgPlayer) // if player, bullet 1 and enemy bullet 1 have bool tags fro dmg player and dmg enemy
        {
            Player_Health.instance.TakePlayerDMG(damage);
        }
        Destroy(gameObject); // Destroy bullet on collision
    }
}
