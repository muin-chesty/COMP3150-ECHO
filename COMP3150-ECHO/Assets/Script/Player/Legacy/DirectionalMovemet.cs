using UnityEngine;

public class DirectionalMovemet : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 2f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
        rb.velocity = transform.up * movement.y * (speed * Time.fixedDeltaTime);
    }
}
