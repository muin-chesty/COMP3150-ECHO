using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float maxRotation;
    public float minRotation;
    public float rotationalSpeed;
    public bool rotateLeft;

    public float timer;
    private float idleTimer;


    enum State
    {
        Idle,
        Rotating
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        idleTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = idleTimer;
                    state = State.Rotating;
                }
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
}
