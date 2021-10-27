using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CameraRotate : MonoBehaviour
{
    public float maxRotation;
    public float minRotation;
    public float rotationalSpeed;
    public bool rotateLeft;

    public float timer;
    private float idleTimer;

    private bool detected;

    public ParticleSystem pivotParticles;
    public ParticleSystem detectionParticles;

    public float particletime;
    private float particletimer;

    private AudioSource audioSource;
    public AudioSource pivotSource;

    public AudioClip detection;
    public AudioClip pivot;

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
        detected = false;
        particletimer = particletime;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = detection;

        pivotSource.clip = pivot;
    }

    // Update is called once per frame
    void Update()
    {
        particletimer -= Time.deltaTime;
        if (particletimer <= 0)
        {
            detected = false;
            detectionParticles.Stop();
            audioSource.Stop();
            audioSource.loop = false;
        }

        if (detected && detectionParticles.isStopped)
        {
            Debug.Log(audioSource.clip);
            detectionParticles.Play();
            audioSource.loop = true;

            audioSource.Play();
        }


        switch (state)
        {
            case State.Idle:
                pivotParticles.Stop();
                pivotSource.Stop();
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = idleTimer;
                    state = State.Rotating;
                }
                break;

            case State.Rotating:
                if (pivotParticles.isStopped)
                {
                    pivotParticles.Play();
                    pivotSource.Play();
                }
                if (!rotateLeft)
                {
                    transform.Rotate(0, 0, rotationalSpeed * Time.deltaTime);
                    if (transform.rotation.eulerAngles.z >= maxRotation || transform.rotation.eulerAngles.z < minRotation)
                    {
                        transform.rotation.eulerAngles.z.Equals(minRotation);
                        pivotSource.Stop();
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
                        pivotSource.Stop();
                        state = State.Idle;
                        timer = idleTimer;
                        rotateLeft = !rotateLeft;
                    }
                }
                break;
        }
    }

    public void Detected(bool state)
    {
        particletimer = particletime;
        detected = state;
    }

}
