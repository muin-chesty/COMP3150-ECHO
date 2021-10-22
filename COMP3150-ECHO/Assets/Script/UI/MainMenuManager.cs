using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelSelectPanel;
    public GameObject creditPanel;
    public GameObject settingsPanel;

    private AudioSource audioSource;

    private void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
    }

    public void LevelSelect()
    {
        audioSource.PlayOneShot(audioSource.clip);
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void Credits()
    {
        audioSource.PlayOneShot(audioSource.clip);
        mainPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void Settings()
    {
        audioSource.PlayOneShot(audioSource.clip);
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(QuitGame());
    }
    public void LevelSelectBack()
    {
        audioSource.PlayOneShot(audioSource.clip);
        mainPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void CreditsBack()
    {
        audioSource.PlayOneShot(audioSource.clip);
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void SettingsBack()
    {
        audioSource.PlayOneShot(audioSource.clip);
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void TutorialLevel()
    {
        audioSource.PlayOneShot(audioSource.clip);
        //SceneManager.LoadScene(1);
        StartCoroutine(Wait(1));
    }

    public void LevelOne()
    {
        audioSource.PlayOneShot(audioSource.clip);
        // SceneManager.LoadScene(2);
        StartCoroutine(Wait(2));
    }


    IEnumerator Wait(int scene)
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene(scene);
    }

    IEnumerator QuitGame()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Application.Quit();
    }
}
