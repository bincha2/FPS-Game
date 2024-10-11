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

    if (enemy != null)
    {
      enemy.TakeDamage(10f);
      Destroy(gameObject);
    }
  }
}
