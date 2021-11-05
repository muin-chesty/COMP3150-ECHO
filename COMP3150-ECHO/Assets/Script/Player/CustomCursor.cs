using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject completePanel;
    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (!pausePanel.activeSelf && !completePanel.activeSelf)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

    }
}
