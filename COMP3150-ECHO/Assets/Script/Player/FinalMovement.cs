using System.Diagnostics;
using UnityEngine;

public class FinalMovement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 10;

    private HealthManager hp;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponent<HealthManager>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(hp.GetHealth() >= 1)
        {
            rb.velocity = movement * speed * Time.fixedDeltaTime;
            rb.rotation = 0f;
            rb.angularVelocity = 0f;
        }
       
    }
}
