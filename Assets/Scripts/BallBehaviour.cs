using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Transform paddle;
    public Rigidbody2D ballRb;
    public bool gameStarted = false;
    public AudioSource ballAudio;

    System.Random R = new System.Random();
    int gamespeed = 20;
    private void Start()
    {
        DeadZone.PlayerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
            transform.position = new Vector3(paddle.position.x + 1, paddle.position.y);

        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            ballRb.velocity = new Vector2(gamespeed, R.Next(-gamespeed, gamespeed));
            gameStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballAudio.Play();
    }
}
