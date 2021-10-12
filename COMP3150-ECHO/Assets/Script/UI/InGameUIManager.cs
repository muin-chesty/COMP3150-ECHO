using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject levelCompletePanel;
    private RestartGame restartSystem;

    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
        restartSystem = FindObjectOfType<RestartGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !levelCompletePanel.active)
        {
            paused = paused ? false : true;
            SetPaused(paused);
        }    
    }

    public void Continue()
    {
        paused = paused ? false : true;
        SetPaused(paused);
    }

    public void Restart()
    {
        restartSystem.RestartWholeGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SetPaused(bool paused)
    {
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
