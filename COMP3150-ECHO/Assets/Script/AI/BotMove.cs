using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMove : MonoBehaviour
{
    public float speed;
    private float velocity;
    public float minTime;
    public float maxTime;

    private float moveTimer;
    private float idleTimer;

    public float minRotationRange;
    public float maxRotationRange;
    private float rotationRange;

    private Vector2 position;
    private Vector2 direction;
    public float distance;

    public LayerMask wallLayer;

    private RaycastHit2D hit;

    enum State
    {
      Idle,
      Moving
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
                transform.Translate(velocity*Time.deltaTime,0,0);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        moveTimer = 0;
        idleTimer = Random.Range(minTime, maxTime);
        rotationRange = transform.rotation.z + Random.Range(minRotationRange, maxRotationRange);
        transform.Rotate(0,0,rotationRange);

        position = transform.position;
        direction = Vector2.up;
        hit = Physics2D.Raycast(position, direction, distance, wallLayer);
        if (hit.collider != null)
        {
            rotationRange = Random.Range(minRotationRange, maxRotationRange); ;
            transform.Rotate(0, 0, rotationRange);
        }
    }
}
