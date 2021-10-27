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

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
        restartSystem = FindObjectOfType<RestartGame>();
        analytics = FindObjectOfType<AnalyticsManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

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
        }

        healthColourTimer -= Time.deltaTime;
        if (healthColourTimer <= 0)
        {
            healthPanel.color = Color.green;
        }
    }

    public void Continue()
    {
        audioSource.PlayOneShot(audioSource.clip);
        paused = paused ? false : true;
        SetPaused(paused);
    }

    public void Restart()
    {
        audioSource.PlayOneShot(audioSource.clip);
        analytics.GameEnded();
        StartCoroutine(RestartCoroutine());
    }

    public void MainMenu()
    {
        audioSource.PlayOneShot(audioSource.clip);
        analytics.GameEnded();
        StartCoroutine(Wait(0));
        ResumeAudio();
        //SceneManager.LoadScene(0);

    }

    void SetPaused(bool paused)
    {
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void NextLevel()
    {
        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(Wait(SceneManager.GetActiveScene().buildIndex + 1));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    IEnumerator Wait(int scene)
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        SceneManager.LoadScene(scene);
    }

    IEnumerator RestartCoroutine()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        restartSystem.RestartWholeGame();
    }


    // TO be credited https://answers.unity.com/questions/194110/how-to-stop-all-audio.html
    private void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }
    }

    private void ResumeAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();
        }
    }

    public void HealthBar(float healthFraction)
    {
        healthColourTimer = healthColourTime;
        healthPanel.color = Color.red;
        healthPanel.rectTransform.sizeDelta = new Vector2(healthBar * healthFraction,
        healthPanel.rectTransform.sizeDelta.y);
    }
}