using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public int keyCode;
    private KeyManager keyManager;
    public KeyEffect keyEffect;
    private KeyEffect keyObject;

    // Start is called before the first frame update
    void Start()
    {
        keyManager = FindObjectOfType<KeyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        keyObject = Instantiate(keyEffect);
        keyManager.KeyCollected(keyCode);
        Destroy(gameObject);
    }
}
