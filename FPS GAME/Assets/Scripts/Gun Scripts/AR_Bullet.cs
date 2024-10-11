using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Bullet : MonoBehaviour
{
  public float life = 3f;

  void Awake()
  {
    Destroy(gameObject, life);
  }
  void OnCollisionEnter(Collision collision)
  {
    Enemy_1 enemy = collision.gameObject.GetComponent<Enemy_1>();

    if (enemy != null) //if it is an enemy, deal dmg and destroy bullet (gameObject)
    {
      enemy.TakeDamage(10f);
      Destroy(gameObject);
    }
    else //i didnt like how bullets bounced off objects so destroy if its not enemy instantly
    {
      Destroy(gameObject);
    }
  }
}
