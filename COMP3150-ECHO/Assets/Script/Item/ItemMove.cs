using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private Vector3 target;
    public float speed = 10f;

    public void SetTarget(Vector3 val)
    {
        target = val;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, (speed * Time.deltaTime));

        if(transform.position == target)
        {
            Destroy(gameObject);
        }
    }
}
