using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    float timer;
    int throwablesUsed;
    string killedBy;
    bool levelComplete;
    bool throwablesDepleted;
    float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        throwablesUsed = 0;
        throwablesDepleted = false;
        levelComplete = false;
        killedBy = "Nothing";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void IncrementThrowablesUsed()
    {
        throwablesUsed++;
    }

    public void PlayerDead(string death)
    {
        killedBy = death;
        timeStamp = timer;
        SubmitAnalytics();
    }

    public void ThrowablesDepleted()
    {
        throwablesDepleted = true;
    }

    public void LevelComplete()
    {
        timeStamp = timer;
        levelComplete = true;
        SubmitAnalytics();
    }

    public void GameEnded()
    {
        SubmitAnalytics();
    }

    private void SubmitAnalytics()
    {
        Analytics.CustomEvent("Game Stats", new Dictionary<string, object>
        {
            {"Death Time", timeStamp },
            {"Throwables Depleted", throwablesDepleted },
            {"Throwables Used", throwablesUsed },
            {"Cuase of Death", killedBy },
            {"Level Completed", levelComplete }
         });
    }
}
