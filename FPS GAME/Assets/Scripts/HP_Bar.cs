using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{

    public static HP_Bar instance;

    public Slider HPslider;
    public TextMeshProUGUI HPtext;

    public int killCount;
    public TextMeshProUGUI KillCounter;


    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

}
