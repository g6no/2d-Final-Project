﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    //SerializedField
    [SerializeField] float bpm;

    public bool hasStarted;

    float beatTempo;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = bpm / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            /* if (Input.anyKeyDown)
            {
                hasStarted = true;
            } */
        }
        else
        {
            transform.position -= new Vector3(0f,beatTempo * Time.deltaTime,0f);
        }
    }
}