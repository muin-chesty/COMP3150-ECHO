using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    private GameObject textObject;
    private Text textPanel;
    [SerializeField]
    private Image textBackground;

    public float textColourTime;
    private float textColourTimer;


    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Tutorial Text Box");
        textPanel = textObject.GetComponent<Text>();
        textPanel.text = "";
        textBackground.color = Color.gray;
        textPanel.color = Color.white;

        textColourTimer = textColourTime;
    }

    private void Update()
    {
        textColourTimer -= Time.deltaTime;
        if (textColourTimer <= 0)
        {
            textBackground.color = Color.gray;
            textPanel.color = Color.white;
        }

        
    }

    public void UpdateTutorialText(string customText)
    {
        textPanel.text = customText;
        textColourTimer = textColourTime;
        textBackground.color = Color.white;
        textPanel.color = Color.black;
    }
}
