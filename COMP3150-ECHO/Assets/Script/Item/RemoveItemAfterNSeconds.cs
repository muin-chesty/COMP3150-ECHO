using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemAfterNSeconds : MonoBehaviour
{
    [SerializeField]
    private float removeAfter = 2f;

    public bool itemStoppedMoving = false;

    [Space]
    public GameObject itemRippleEffect;

    void Start()
    {
        StartCoroutine(Remove());

    }
    
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(removeAfter);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

         Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObject temp = Instantiate(itemRippleEffect);
        temp.transform.position = transform.position;
    }
}
