using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemAfterNSeconds : MonoBehaviour
{
    [SerializeField]
    private float removeAfter = 2f;
    void Start()
    {
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(removeAfter);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
