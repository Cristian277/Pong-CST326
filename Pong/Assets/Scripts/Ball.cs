﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPosition;
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector3(speed * x, speed * y,0f);
    }

}