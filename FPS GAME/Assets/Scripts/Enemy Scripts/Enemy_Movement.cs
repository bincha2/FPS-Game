using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    public float movementSpeed;
    public float distanceFromPlayer;
    public GameObject bullet;
    public Transform firePoint;
    public float firerate;
    public float waitTime = 2f;
    public float nextFire = 1f;
    private float fireCountdown;
    private float waitTimeCountdown;
    private float nextFireCountdown;
    private Vector3 target;
    public NavMeshAgent agent; //use ai nav

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nextFireCountdown = nextFire;
        waitTimeCountdown = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        target = Player_Movement.instance.transform.position;
        agent.destination = target; //destination for enemy is the target pos (player)


        if (Vector3.Distance(transform.position, target) > distanceFromPlayer)
        {
            nextFireCountdown = nextFire;
            waitTimeCountdown = waitTime;

            agent.destination = target;
            animator.SetBool("isMoving", true);
        }
        else
        {
            agent.destination = transform.position;
            animator.SetTrigger("fire");

            if (Vector3.Distance(transform.position, target) <= distanceFromPlayer && Player_Movement.instance.gameObject.activeInHierarchy)
            {
                fireCountdown -= Time.deltaTime;

                if (fireCountdown <= 0)
                {
                    fireCountdown = firerate;

                    firePoint.LookAt(Player_Movement.instance.transform.position);

                    Vector3 direction = (Player_Movement.instance.transform.position - firePoint.position).normalized; // direction for the enemy to shoot at player
                    float shootingAngle = Vector3.SignedAngle(direction, firePoint.forward, Vector3.up);

                    if (Mathf.Abs(shootingAngle) < 45f)
                    {
                        Instantiate(bullet, firePoint.position, firePoint.rotation);

                        animator.SetTrigger("fire");
                    }

                    if (agent.remainingDistance < 0.3f)
                    {
                        animator.SetBool("isMoving", false);
                    }
                    else
                    {
                        animator.SetBool("isMoving", true);
                    }
                }
            }
        }
    }
}


