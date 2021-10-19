using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GoalLevelLoader : MonoBehaviour
{
    public GameObject levelCompletePanel;
    private AnalyticsManager analytics;

    private void Start()
    {
        analytics = FindObjectOfType<AnalyticsManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        analytics.LevelComplete();
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
