using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EyeBotMove : MonoBehaviour
{
    //If the bot moves on a scripted path
    public List<GameObject> Waypoints = new List<GameObject>();

    public ParticleSystem soundWaveEffect;

    public bool staticRotate;

    private int index;
    public float speed;

    private Vector3 waypoint;
    private Vector3 direction;

    // Implement Rotation Only
    public float minTime;
    public float maxTime;
    private float timer;

    public float rotationSpeed;

    //Implement Sound waves system - Complete rundown
    private AudioSource audioSource;

    enum State
    {
        Moving,
        Turning,

        // for statically turning eye bots only
        Idle,
        StaticRotate
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
        soundWaveEffect = GetComponentInChildren<ParticleSystem>();
        soundWaveEffect.Stop();

        audioSource = GetComponent<AudioSource>();

        if (staticRotate)
        {
            state = State.Idle;
        }
        else
        {
            index = 0;
            transform.position = Waypoints[index].transform.position;
            waypoint = Waypoints[index++].transform.position;
            state = State.Moving;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Moving:
                waypoint = Waypoints[index].transform.position;
                if (soundWaveEffect.isStopped)
                {
                    audioSource.Play();
                    audioSource.loop = true;
                    soundWaveEffect.Play();
                }
                // Calculates the distance traveled and the distance to the waypoint
                float distanceTravelled = speed * Time.deltaTime;
                float distanceToWaypoint = Vector3.Distance(waypoint, transform.position);

                // move towards waypoint
                Vector3 direction = waypoint - transform.position;
                direction = direction.normalized;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
                if (distanceToWaypoint <= distanceTravelled)
                {
                    // reached the waypoint, start heading to the next one
                    transform.position = waypoint;
                    if (index < Waypoints.Count - 1)
                    {
                        //Goes to next waypoint
                        index++;
                    }
                    else
                    {
                        //Path completed starting from the begining 
                        index = 0;
                    }
                    state = State.Turning;
                }
                else
                {
                    // Moving
                    transform.Translate(direction * distanceTravelled, Space.World);
                }
                break;

            case State.Turning:
                if (soundWaveEffect.isStopped)
                {
                    audioSource.Play();
                    soundWaveEffect.Play();
                }
                direction = waypoint - transform.position;
                direction = direction.normalized;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
                state = State.Moving;
                break;

            case State.Idle:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    audioSource.Stop();
                    state = State.StaticRotate;
                    timer = Random.Range(minTime, maxTime);
                }
                break;

            case State.StaticRotate:

                timer -= Time.deltaTime;
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                // play ripptle effect
                if (soundWaveEffect.isStopped)
                {
                    audioSource.Play();
                    audioSource.loop = true;
                    soundWaveEffect.Play();

                }

                if (timer <= 0)
                {
                    soundWaveEffect.Stop();
                    audioSource.Stop();
                    state = State.Idle;
                    timer = Random.Range(minTime, maxTime);
                }
                break;
        }

    }

}
