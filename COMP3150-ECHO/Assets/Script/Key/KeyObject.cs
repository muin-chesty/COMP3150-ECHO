using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public int keyCode;
    private KeyManager keyManager;
    public ParticleSystem indicatorEffect;
    public float timer;
    private float timerCounter;

    // Start is called before the first frame update
    void Start()
    {
        timerCounter = timer;
        keyManager = FindObjectOfType<KeyManager>();
        indicatorEffect = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        timerCounter -= Time.deltaTime;
        if (timerCounter <= 0)
        {
            if (indicatorEffect.isStopped)
            {
                indicatorEffect.Play();
            }
            timerCounter = timer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        keyManager.KeyCollected(keyCode);
        Destroy(gameObject);
    }
}
