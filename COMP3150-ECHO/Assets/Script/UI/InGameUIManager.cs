using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class InGameUIManager : MonoBehaviour
{
    // Audio Elements
    private AudioSource[] allAudioSources;
    private AudioSource audioSource;

    //UI Elements
    public GameObject pausePanel;
    public GameObject levelCompletePanel;
    private RestartGame restartSystem;

    // Health UI Elements
    public Image healthPanel;
    private float healthBar;

    //Analytics
    private AnalyticsManager analytics;

    private bool paused;

    public float healthColourTime;
    private float healthColourTimer;

    //private AudioListener audioListener;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
        restartSystem = FindObjectOfType<RestartGame>();
        analytics = FindObjectOfType<AnalyticsManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        healthBar = healthPanel.rectTransform.sizeDelta.x;
        healthColourTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !levelCompletePanel.activeSelf)
        {
            StopAllAudio();
            paused = paused ? false : true;
            SetPaused(paused);
            if(paused == false)
            {
                ResumeAudio();
            }
        }

        healthColourTimer -= Time.deltaTime;
        if (healthColourTimer <= 0)
        {
            healthPanel.color = Color.green;
        }
    }

    public void Continue()
    {
        audioSource.Play();
        StartCoroutine(WaitForAudio(audioSource));
        paused = paused ? false : true;
        SetPaused(paused);
        ResumeAudio();
    }

    public void Restart()
    {
        audioSource.Play();
        analytics.GameEnded();
        StartCoroutine(RestartCoroutine(audioSource));
    }

    public void MainMenu()
    {
        audioSource.Play();
        analytics.GameEnded();
        StartCoroutine(Wait(0, audioSource));
        ResumeAudio();

    }

    void SetPaused(bool paused)
    {
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void NextLevel()
    {
        audioSource.Play();
        StartCoroutine(Wait(SceneManager.GetActiveScene().buildIndex + 1,audioSource));
    }

    IEnumerator Wait(int scene, AudioSource aud)
    {
        yield return new WaitUntil(() => aud.isPlaying == false);
        SceneManager.LoadScene(scene);
    }

    IEnumerator RestartCoroutine(AudioSource aud)
    {
        yield return new WaitUntil(() => aud.isPlaying == false);
        restartSystem.RestartWholeGame();
    }

    IEnumerator WaitForAudio(AudioSource aud)
    {
        yield return new WaitUntil(() => aud.isPlaying == false);
    }

    private void StopAllAudio()
    {
        AudioListener.pause = true;
    }

    private void ResumeAudio()
    {
        AudioListener.pause = false;
    }

    public void HealthBar(float healthFraction)
    {
        healthColourTimer = healthColourTime;
        healthPanel.color = Color.red;
        healthPanel.rectTransform.sizeDelta = new Vector2(healthBar * healthFraction,
        healthPanel.rectTransform.sizeDelta.y);
    }
}