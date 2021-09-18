using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUI : MonoBehaviour
{
    [SerializeField]
    private ThrowItem throwScript;
    [SerializeField]
    private Text nutText;

  
    void Update()
    {
        nutText.text = "Nuts & Bolts: " + throwScript.GetAmmoCount();
     
    }
}
