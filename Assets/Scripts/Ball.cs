using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Vector2 ballPos;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] bool isStarted;               //Flag variable

    [SerializeField] Paddle paddle;
    Vector2 paddleToBallVector;

    //Audio
    AudioSource myAudioSource;
    [SerializeField] AudioClip paddleHitClip;
    [SerializeField] [Range(0, 1)] float paddleHitVolume = 1f;
    [SerializeField] AudioClip blockHitClip;
    [SerializeField] [Range(0, 1)] float blockHitVolume = 1f;
    [SerializeField] AudioClip floorHitClip;
    [SerializeField] [Range(0, 1)] float floorHitVolume = 1f;
    [SerializeField] AudioClip wallHitClip;
    [SerializeField] [Range(0, 1)] float wallHitVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;

        //Calculate distance between ball and paddle
        paddleToBallVector = transform.position - paddle.transform.position;

        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);

        if ((collision.gameObject.tag == "Paddle") & isStarted)
        {
            Debug.Log("paddle hit sound");
            myAudioSource.PlayOneShot(paddleHitClip);
        }

        if (collision.gameObject.tag == "Block")
        {
            Debug.Log("block hit sound");
            myAudioSource.PlayOneShot(blockHitClip);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("wall hit sound");
            myAudioSource.PlayOneShot(wallHitClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("floor hit sound");
            myAudioSource.PlayOneShot(floorHitClip);

            SceneLoader sceneloader = FindObjectOfType<SceneLoader>();
            sceneloader.LoadGameOver();
        }
    }


}
