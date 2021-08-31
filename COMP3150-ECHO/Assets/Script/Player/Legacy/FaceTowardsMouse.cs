using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowardsMouse : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 mousePos;
    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
       
            Vector2 lookDir = mousePos - rb.position;

            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

            rb.rotation = angle;

    }
}

