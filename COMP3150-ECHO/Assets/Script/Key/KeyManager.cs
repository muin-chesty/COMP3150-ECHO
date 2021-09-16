using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private Keys key;

    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Keys>();
    }

    public void KeyCollected(int i)
    {
        key.SetKeyStatus(i);
    }

    public bool CheckKeyFound(int i)
    {
        bool status = key.KeyStatus(i);
        return status;
    }

}
