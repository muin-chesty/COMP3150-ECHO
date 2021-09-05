using UnityEngine;

public class FinalMovement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed * Time.fixedDeltaTime;
        ;
        rb.rotation = 0f;
        rb.angularVelocity = 0f;
    }
}
