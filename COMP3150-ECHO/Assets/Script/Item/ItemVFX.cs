using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ItemVFX : MonoBehaviour
{
    private ParticleSystem soundWaveEffect;
    private float timeToLive;

    // Start is called before the first frame update
    void Start()
    {
        soundWaveEffect = GetComponent<ParticleSystem>();
        timeToLive = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {


        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            soundWaveEffect.Stop();
            if (soundWaveEffect.particleCount < 0)
            {
                Destroy(gameObject, 2.0f);
            }
        }
    }
}
