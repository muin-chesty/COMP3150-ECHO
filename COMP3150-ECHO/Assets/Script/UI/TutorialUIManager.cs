using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TutorialUIManager : MonoBehaviour
{
    private GameObject textObject;
    private Text textPanel;

    private string customText;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Tutorial Text Box");
        textPanel = textObject.GetComponent<Text>();
        textPanel.text = "";
    }

    public void UpdateTutorialText(string customText)
    {
        textPanel.text = customText;
    }
}
