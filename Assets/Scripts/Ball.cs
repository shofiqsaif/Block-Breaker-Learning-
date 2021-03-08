using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config Param
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 launchVelocity;
    [SerializeField] AudioClip[] ballSounds;
    
    // States
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    int ballYDirection = 1;
    int ballXDirection = 1;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector =  (transform.position - paddle1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);

        GetComponent<Rigidbody2D>().velocity = new Vector2(ballXDirection * launchVelocity.x, ballYDirection * launchVelocity.y);
        if (!hasStarted)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collidedWith = collision.gameObject.name;
        if ( collidedWith == "Right Wall" || collidedWith == "Left Wall")
        {
            ballXDirection = -ballXDirection;
        }
        else
        {
            ballYDirection = -1 * ballYDirection;
        }

        //AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
        //GetComponent<AudioSource>().PlayOneShot(clip);
        
        //Debug.Log(collision.gameObject.name);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, launchVelocity.y);
    }
}
