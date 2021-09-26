using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Keys : MonoBehaviour
{
    private static Keys keyCollection;
    private VFXPlayer playerVisualEffects;
    public List<bool> keyStatus = new List<bool>();

    private void Start()
    {
        playerVisualEffects = FindObjectOfType<VFXPlayer>();
    }

    public void AddKey(bool status)
    {
        keyStatus.Add(status);
    }

    public bool KeyStatus(int i)
    {
        if (i < keyStatus.Count)
        {
            return keyStatus[i];
        }
        // No key found
        return false;
    }

    public void SetKeyStatus(int i) 
    {
        if (i < keyStatus.Count)
        {
            keyStatus[i] = true;
            TriggerParticles();
        }
    }

    private void TriggerParticles()
    {
        playerVisualEffects.KeyCollectedEffects();
    }
}


