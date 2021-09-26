using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeafBot : MonoBehaviour
{

    public float timerInterval;
    private float timer;
    private ParticleSystem deaf;

    // Start is called before the first frame update
    void Start()
    {
        deaf = GetComponentInChildren<ParticleSystem>();
        timer = timerInterval;
        deaf.Stop();
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
            }
            if (deaf.isStopped && deaf.particleCount<=0)
            {
                timer = timerInterval;
            }
        }
    }
}
