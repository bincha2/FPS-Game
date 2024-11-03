using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; // bullet speed
    public float lifetime; // liftetime of bullet
    private Rigidbody rb;

    public int damage; //dnmg of bullet

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.velocity = transform.forward * bulletSpeed; 
        Destroy(gameObject, lifetime); // Destroy after lifetime
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy_Health>().TakeDMG(damage);
        }
        Destroy(gameObject); // Destroy bullet on collision
    }
}
