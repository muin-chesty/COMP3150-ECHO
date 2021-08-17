using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMouseMovement : MonoBehaviour
{
    private Camera cam;
    private Vector2 lastMouseClick;

    [SerializeField]
    private float speed = 5f;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        // LEFT CLICK
        if (Input.GetMouseButton(0))
        {
            lastMouseClick = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, lastMouseClick, (speed * Time.deltaTime));

        }
        if (!lastMouseClick.Equals(transform.position))
        {

        }

    }
}
