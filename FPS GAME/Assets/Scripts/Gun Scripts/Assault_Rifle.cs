using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assault_Rifle : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    public float bulletSpeed =  10f;

    void Update()
    {
        if (Pause_Menu.isPaused) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
