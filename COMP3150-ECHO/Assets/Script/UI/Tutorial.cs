using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Tutorial : MonoBehaviour
{
    private GameObject textObject;
    private Text textPanel;
    public string customText;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Tutorial Text Box");
        textPanel = textObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(textPanel.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textPanel.text = customText;
    }
}
