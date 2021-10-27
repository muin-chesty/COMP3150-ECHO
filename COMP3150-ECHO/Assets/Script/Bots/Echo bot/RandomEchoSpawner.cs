using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomEchoSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Drag in Particle system for Echo bot")]
    private ParticleSystem ps;
    [Space]
    [SerializeField]
    private float maxRange = 5f;
    [SerializeField]
    private float minRange = 1f;
    private float timer = 0f;

    private AudioSource audioSource;
    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

        timer = Random.Range(minRange,maxRange);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (ps.isStopped && timer <= 0)
        {
            ps.Play();
            audioSource.Play();
            timer = Random.Range(minRange, maxRange);
        } 
    }
}
