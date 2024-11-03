using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody rb;
    private Vector3 target;
    public NavMeshAgent agent; //use ai nav


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = Player_Movement.instance.transform.position;
        target.y = transform.position.y;

        agent.destination = target; //destination for enemy is the target pos (player)
       
    }
}
