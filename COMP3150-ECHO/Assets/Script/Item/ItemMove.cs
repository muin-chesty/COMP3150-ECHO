using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private Vector3 target;
    public float speed = 10f;
    [Space]
    public GameObject itemRippleEffect;
    public Transform p1;
    private int bounceCounter = 0;
    Rigidbody2D rb;

    [SerializeField]
    [Tooltip("NUMBER OF TIMES NUTS AND BOLTS WOULD BOUNCE WHEN DROPPED ON THE GROUND")]
    private int bounceLimit = 3;

    [SerializeField]
    [Tooltip("VAL (0.1-3) FRICTION FOR WHEN DROPPED ON THE GROUND")]
    private float groundFriction = 2.5f;

    RemoveItemAfterNSeconds hitSomething;


    void Start()
    {
        hitSomething = GetComponent<RemoveItemAfterNSeconds>();
        p1 = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
       
       
    }
    public void SetTarget(Vector3 val)
    {
        target = val;
    }

    public void Reverse()
    {
        target = transform.GetChild(1).position;
    }

    void Update()
    {
        if(hitSomething.isCollided == false)
        {
            Vector2 lookDir = target - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            transform.position = Vector2.MoveTowards(transform.position, target, (speed * Time.deltaTime));

            if (transform.position == target)
            {
              
               
                GameObject temp = Instantiate(itemRippleEffect);
                temp.transform.position = transform.position;
                target = p1.position;
                bounceCounter++;
                speed -= groundFriction;
                if (bounceCounter >= bounceLimit)
                {
                    Destroy(gameObject);
                }
            }

        }
        
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, ((speed/2) * Time.deltaTime));
           
            Vector2 lookDir = target - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;
        
            if (transform.position == target)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
