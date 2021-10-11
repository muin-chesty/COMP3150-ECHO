using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private TutorialUIManager tutorialManager;
    private bool activated;
    public string customText;

    void Start()
    {
        tutorialManager = FindObjectOfType<TutorialUIManager>();
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            tutorialManager.UpdateTutorialText(customText);
            activated = true;
        }
    }
}
