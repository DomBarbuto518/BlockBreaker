using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 ballPos;
    [SerializeField] float initialBallVelocity = 5f;
    [SerializeField] bool isLaunched;               //Flag variable

    // Start is called before the first frame update
    void Start()
    {
        isLaunched = false;
        Debug.Log("Ball is not launched");
    }

    // Update is called once per frame
    void Update()
    {
        //Track Balls Position
        ballPos = transform.position;

        //Launch Ball
        LaunchBall(initialBallVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
    }

    /**
     * Uses the flag variable isLaunched to ensure the ball can only be launched once. 
     * On start, isLaunched is false. Once mouse is clicked, ball is launched and isLaunched = true.
     **/
    private void LaunchBall(float velocity)
    {
       if(!isLaunched & Input.GetMouseButtonDown(0))
        {
            isLaunched = true;
            Debug.Log("Ball is launched");
            //Obtain reference to this game objects RigidBody2D component
            Rigidbody2D ballRigidBody2D = GetComponent<Rigidbody2D>();
            //Set velocity of ball
            ballRigidBody2D.velocity = new Vector2(0, velocity);
        }
        
    }
}
