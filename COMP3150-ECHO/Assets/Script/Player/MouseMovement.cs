using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Camera cam;
    private Vector2 lastMouseClick;
    public static bool isClicked = false;

   

    [SerializeField]
    private float speed = 5f;
    void Start()
    {
        cam = Camera.main;
        
    }
    void Update()
    {
        // LEFT CLICK
        if(Input.GetMouseButtonDown(0))
        {
            lastMouseClick = cam.ScreenToWorldPoint(Input.mousePosition);

        }
        if(!lastMouseClick.Equals(transform.position))
        {
            transform.position =  Vector2.MoveTowards(transform.position, lastMouseClick, (speed * Time.deltaTime));
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }
        

    }
}
