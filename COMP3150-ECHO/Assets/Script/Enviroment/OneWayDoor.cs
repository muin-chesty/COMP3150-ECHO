using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OneWayDoor : MonoBehaviour
{
    public GameObject door;
    public float distance;
    private float speed;
    private float doorPosition;
    private AudioSource audioSource;

    enum State
    {
        Opening,
        Closeing,
        Idle
    };

    private State state;


    // Start is called before the first frame update
    void Start()
    {

        speed = 10;
        state = State.Idle;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case State.Opening:
                door.transform.Translate(speed * Time.deltaTime, 0, 0);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                if (door.transform.localPosition.x >= distance)
                {
                    doorPosition = Mathf.Clamp(door.transform.localPosition.x, 0, distance);
                    door.transform.localPosition = new Vector3(doorPosition, 0, 0);
                    audioSource.Stop();
                    state = State.Idle;
                }
                break;

            case State.Closeing:
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                door.transform.Translate(-speed * Time.deltaTime, 0, 0);
                if (door.transform.localPosition.x <= 0)
                {
                    doorPosition = Mathf.Clamp(door.transform.localPosition.x, 0, distance);
                    door.transform.localPosition = new Vector3(doorPosition, 0, 0);
                    audioSource.Stop();
                    state = State.Idle;
                }
                break;

            case State.Idle:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            state = State.Opening;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        state = State.Closeing;
    }
}
