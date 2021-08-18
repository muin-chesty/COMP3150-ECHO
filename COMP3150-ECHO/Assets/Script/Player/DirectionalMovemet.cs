using UnityEngine;

public class DirectionalMovemet : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rigidbody;
    [SerializeField]
    private float speed = 2f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
    }

    private void FixedUpdate()
    {
        Debug.Log(rigidbody.velocity);
        rigidbody.velocity = transform.up * movement.y * (speed * Time.fixedDeltaTime);
    }
}
