using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GoalLevelLoader : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    public GameObject levelCompletePanel;
    private AnalyticsManager analytics;
    

    private void Start()
    {
        analytics = FindObjectOfType<AnalyticsManager>();
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        analytics.LevelComplete();
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0;
        StopAllAudio();
    }

    private void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }
    }

}
