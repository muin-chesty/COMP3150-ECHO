using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // FOR VFX COMING FROM MOUSE SCRIPTS
        if (movement.Equals(Vector2.zero))
        {
            MouseMovement.isClicked = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = ((transform.up * movement.y) +
            (transform.right * movement.x))
            * moveSpeed * Time.fixedDeltaTime;
            ;
    }
}
