using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
   public float hp = 50f;

   public void TakeDamage(float damage)
   {
        hp -= damage;
        if (hp <= 0f)
        {
         Die();
        }
   }

   public void Die()
   {
    Destroy(gameObject);
   }
}
