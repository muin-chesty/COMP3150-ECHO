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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nutText.text = "Nuts : " + throwScript.GetAmmoCount();
    }
}