using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBotMove : MonoBehaviour
{
    public float timer;
    private float idleTimer;

    public float speed;

    public float maxRotation;
    public float minRotation;
    public float rotationalSpeed;
    public bool rotateLeft;
    public bool rotationalMovementOnly;


    enum State
    {
        Idle,
        Moving,
        Rotating,

        RotateOnly
    };

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        idleTimer = timer;

        //If the bot doesn;t need to move and only turn around in circles 
        if (rotationalMovementOnly)
        {
            state = State.RotateOnly;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                timer -= Time.deltaTime;
                if(timer<= 0)
                {
                    state = State.Moving;
                }
                break;

            case State.Moving:
                transform.Translate(0, speed * Time.deltaTime, 0); ;
                break;

            case State.Rotating:
                if (!rotateLeft)
                {
                    transform.Rotate(0, 0, rotationalSpeed * Time.deltaTime);
                    if (transform.rotation.eulerAngles.z >= maxRotation || transform.rotation.eulerAngles.z < minRotation)
                    {
                        transform.rotation.eulerAngles.z.Equals(minRotation);
                        state = State.Idle;
                        timer = idleTimer;
                        rotateLeft = !rotateLeft;
                    }
                }
                else
                {
                    transform.Rotate(0, 0, -rotationalSpeed * Time.deltaTime);
                    if (transform.rotation.eulerAngles.z <= minRotation || transform.rotation.eulerAngles.z > maxRotation)
                    {
                        transform.rotation.eulerAngles.z.Equals(maxRotation);
                        state = State.Idle;
                        timer = idleTimer;
                        rotateLeft = !rotateLeft;
                    }

                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        state = State.Rotating;
    }
}
