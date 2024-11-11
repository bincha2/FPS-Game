using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Spawn : MonoBehaviour
{
    public GameObject HP;

    public float Spawnrate;
    private float Spawncount;

    // Start is called before the first frame update
    void Start()
    {
        Spawncount = Spawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        Spawncount -= Time.deltaTime;

        if (Spawncount <= 0)
        {
            Spawncount = Spawnrate;
            Instantiate(HP, transform.position, transform.rotation);
        }
    }
}
