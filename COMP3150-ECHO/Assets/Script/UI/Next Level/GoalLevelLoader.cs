using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GoalLevelLoader : MonoBehaviour
{
    public GameObject levelCompletePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
