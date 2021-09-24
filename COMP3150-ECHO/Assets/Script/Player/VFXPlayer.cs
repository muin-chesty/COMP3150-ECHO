using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class VFXPlayer : MonoBehaviour
{
    public ParticleSystem soundWaveEffect;
    Vector2 movement;
    Rigidbody2D rb;
    private float alpha = 1.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = soundWaveEffect.main;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        main.startColor = new Color(main.startColor.color.r,
                main.startColor.color.g,
                main.startColor.color.b,
                alpha);
        if (rb.velocity != Vector2.zero && movement != Vector2.zero)
        {
            if (soundWaveEffect.isStopped)
            {
                soundWaveEffect.Play();
            }
        }
        else
        {
            soundWaveEffect.Stop();
        }
    }
}
