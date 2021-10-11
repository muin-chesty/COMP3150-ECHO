using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelSelectPanel;
    public GameObject creditPanel;
    public GameObject settingsPanel;

    private void Start()
    {

    }

    public void LevelSelect()
    {
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void Credits()
    {
        mainPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void Settings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void LevelSelectBack()
    {
        mainPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void CreditsBack()
    {
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void SettingsBack()
    {
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void TutorialLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }

}
