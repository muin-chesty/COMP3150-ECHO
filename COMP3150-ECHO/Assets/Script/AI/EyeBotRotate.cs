using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBotRotate : MonoBehaviour
{
    public float minTime;
    public float maxTime;

    private float timer;

    public float rotationSpeed;
    public ParticleSystem soundWaveEffect;

    enum State
    {
        Idle,
        Turning,
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
        soundWaveEffect = GetComponentInChildren<ParticleSystem>();
        soundWaveEffect.Stop();
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
                    state = State.Turning;
                    timer = Random.Range(minTime, maxTime);
                }
                break;

            case State.Turning:

                timer -= Time.deltaTime;
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                // play ripptle effect
                if (soundWaveEffect.isStopped)
                {
                    soundWaveEffect.Play();
                }
                if (timer <= 0)
                {
                    soundWaveEffect.Stop();
                    state = State.Idle;
                    timer = Random.Range(minTime, maxTime);
                }

                break;
        }

    }
}
