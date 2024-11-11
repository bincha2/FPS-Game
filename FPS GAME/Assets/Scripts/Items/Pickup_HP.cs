using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_HP : MonoBehaviour
{
    public int heal;

    private void OnTriggerEnter(Collider other) // when player interacts w sphgere collider of hp
    {
        if (other.tag == "Player") // if player
        {
            Player_Health.instance.PickupHealth(heal); // call heal function, heal plauer

            Destroy(gameObject); // destopry the obj
        }
    }
}
