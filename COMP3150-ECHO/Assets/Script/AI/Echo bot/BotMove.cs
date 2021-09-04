using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public float speed;
    private float velocity;
    public float minTime;
    public float maxTime;

    public float rotationalSpeed;

    private float moveTimer;
    private float idleTimer;

    public float minRotationRange;
    public float maxRotationRange;
    private float rotationRange;

    private float rotated;
    private float direction;

    enum State
    {
      Idle,
      Moving,
      Rotating
    };

    private State state;

    void Start()
    {
        idleTimer = Random.Range(minTime, maxTime);
        velocity = speed;
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:

                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0)
                {
                    moveTimer = Random.Range(minTime, maxTime);
                    state = State.Moving;
                }

                break;

            case State.Moving:

                moveTimer -= Time.deltaTime;
                if (moveTimer <= 0)
                {
                    idleTimer = Random.Range(minTime, maxTime);
                    state = State.Idle;
                }

                // Rotate towards a location not looking at the wall
                // Ray casting

                // Move forward
                velocity = speed;
                transform.Translate(0, velocity * Time.deltaTime, 0);
                break;

            case State.Rotating:

                transform.Rotate(0,0,(rotationalSpeed*direction)*Time.deltaTime);
                rotated += rotationalSpeed * Time.deltaTime;
                if(rotated >= rotationRange)
                {
                    moveTimer = Random.Range(minTime, maxTime);
                    idleTimer = 0;
                    rotated = 0;
                    state = State.Moving;
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (state != State.Rotating)
        {
            if (transform.rotation.z <= 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            moveTimer = 0;
            idleTimer = Random.Range(minTime, maxTime);
            rotationRange = Random.Range(minRotationRange, maxRotationRange);
            state = State.Rotating;
        }
    }
}
