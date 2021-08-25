using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
    public ParticleSystem soundWaveEffect;
    public GameObject light;
    Vector2 movement;
    Rigidbody2D rb;
    
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
        if (rb.velocity != Vector2.zero || MouseMovement.isClicked)
        {
            
            if(light !=  null)
            {
                light.SetActive(true);
            }
            
            main.startColor = new Color(main.startColor.color.r,
                main.startColor.color.g,
                main.startColor.color.b,
                1f);

        }
        else
        {
            if(light != null)
            {
                light.SetActive(false);
            }
            
            main.startColor = new Color(main.startColor.color.r,
               main.startColor.color.g,
               main.startColor.color.b,
               0f);

        }
    }
}
