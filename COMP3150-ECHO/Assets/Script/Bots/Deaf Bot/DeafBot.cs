using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DeafBot : MonoBehaviour
{ 
    public float timerInterval;
    private float timer;
    private ParticleSystem deaf;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        deaf = GetComponentInChildren<ParticleSystem>();
        timer = timerInterval;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (deaf.isStopped)
            {
                deaf.Play();
                audioSource.Play();
            }
            if (deaf.isStopped && deaf.particleCount<=0)
            {
                StartCoroutine(WaitAndStop());
                timer = timerInterval;
            }
            Debug.Log(deaf.particleCount/100000f);
            audioSource.volume = deaf.particleCount/200000f;
        }
    }

    IEnumerator WaitAndStop()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
    }
}
