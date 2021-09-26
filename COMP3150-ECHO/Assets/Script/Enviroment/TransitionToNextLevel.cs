using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine;

public class TransitionToNextLevel : MonoBehaviour
{
    public GameObject nextLevelPanel;

    //Feel fee to modify this platform however you like
    // Inorder to make it work for next level transitions.

    // Start is called before the first frame update
    void Start()
    {
        nextLevelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        nextLevelPanel.SetActive(true);
    }
}
