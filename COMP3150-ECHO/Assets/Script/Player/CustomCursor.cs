using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       transform.position =  pos;
    }
}
