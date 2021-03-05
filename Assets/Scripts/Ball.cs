﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config Param
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 launchVelocity;
    
    // States
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector =  (transform.position - paddle1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
        
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = launchVelocity;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }
}
