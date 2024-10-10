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
    Destroy(collision.gameObject);
    Destroy(gameObject);
  }
}
