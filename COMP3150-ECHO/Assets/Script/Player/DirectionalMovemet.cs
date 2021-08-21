using UnityEngine;

public class DirectionalMovemet : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D rigidbody;
    [SerializeField]
    private float speed = 2f;
    public GameObject rippleEffect;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x > 0.01f || movement.y > 0.00000000001f)
        {
            rippleEffect.SetActive(true);
        }
        else
        {
            rippleEffect.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.up * movement.y * (speed * Time.fixedDeltaTime);
    }
}
