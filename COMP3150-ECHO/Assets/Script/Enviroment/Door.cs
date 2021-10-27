using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    private KeyManager keyManager;

    public GameObject door;
    public float distance;
    private float speed;
    private float doorPosition;
    public bool keyRequired;
    public int keyCode;
    private bool keyFound;
    private bool neverOpened;
    public ParticleSystem particle;

    public AudioClip hum;
    public AudioClip openClose;
    private AudioSource audioSource;
    private bool isPlaying;

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
        keyManager = FindObjectOfType<KeyManager>();
        audioSource = GetComponent<AudioSource>();
        speed = 10;
        state = State.Idle;
        keyFound = false;
        neverOpened = true;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        keyFound = keyManager.CheckKeyFound(keyCode);
        if (neverOpened && keyRequired && keyFound && particle.isStopped)
        {
            particle.Play();
            if (!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.clip = hum;
                audioSource.Play();
            }
            
        }
        else if(!neverOpened)
        {
            particle.Stop();
            audioSource.loop = false;
            //audioSource.Stop();
        }

        switch (state)
        {
            case State.Opening:
                neverOpened = false;
                door.transform.Translate(speed * Time.deltaTime, 0, 0);
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = openClose;
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
                
                door.transform.Translate(-speed * Time.deltaTime, 0, 0);
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = openClose;
                    audioSource.Play();
                }
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
        if (keyRequired == true)
        {
            if (keyFound)
            {
                state = State.Opening;
            }
        }
        else
        {
            state = State.Opening;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        state = State.Closeing;
    }
}
