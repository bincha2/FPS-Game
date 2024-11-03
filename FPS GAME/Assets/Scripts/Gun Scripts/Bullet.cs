using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float lifetime; // Set a default lifetime if not set in the Inspector
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
        rb.velocity = transform.forward * bulletSpeed; // Set initial velocity
        Destroy(gameObject, lifetime); // Destroy after lifetime
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroy bullet on collision
    }
}
