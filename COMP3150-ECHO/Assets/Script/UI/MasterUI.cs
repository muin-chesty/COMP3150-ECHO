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
    private TutorialSetting config;
    private bool tutorial;
    private void Start()
    {
        config = FindObjectOfType<TutorialSetting>();
        if (config != null)
        {
            tutorial = config.isTutorial();
        }
    }
    void Update()
    {
        if (!tutorial)
        {
            nutText.text = "Nuts & Bolts: " + throwScript.GetAmmoCount();
        }
        else
        {
            nutText.text = "Nuts & Bolts: ∞";
        }
     
    }
}
