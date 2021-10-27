using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerV2 : MonoBehaviour
{
    // Health Values
    public float maxHealth;
    private float health;
    private float damage;

    // UI elements
    [SerializeField]
    private GameObject gameoverCanvas;
    [SerializeField]
    private GameObject uiCanvas;
    [SerializeField]
    private InGameUIManager uiManager;

    // Level Config
    private TutorialSetting config;
    private bool tutorial;

    // Analytics
    private AnalyticsManager analytics;

    //Entity player is killed by
    private GameObject entityObject;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 1f;
        config = FindObjectOfType<TutorialSetting>();
        analytics = FindObjectOfType<AnalyticsManager>();
        uiManager = FindObjectOfType<InGameUIManager>();

        // Checks If Level is a Tutorial
        if (config != null)
        {
            tutorial = config.isTutorial();
        }
        else
        {
            tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.backgroundColor = Color.black;
        // Health bar

        if (health <= 0)
        {
            PlayerIsDead();
        }
    }


    public void ReduceHealth(GameObject entity)
    {
        if (!tutorial)
        {
            Camera.main.backgroundColor = Color.red;
            entityObject = entity;
            health -= damage;
            Debug.Log(health / maxHealth);
            uiManager.HealthBar(health/maxHealth);
        }
        else
        {
            TutorialDamage();
        }
    }

    private void PlayerIsDead()
    {
        if (entityObject != null)
        {
            analytics.PlayerDead(entityObject.transform.parent.name);
        }

        uiCanvas.SetActive(false);
        gameoverCanvas.SetActive(true);
        Destroy(GetComponent<SpriteRenderer>());
        Time.timeScale = 0;
    }

    private void TutorialDamage()
    {
        Camera.main.backgroundColor = Color.red;
    }

    public float GetHealth()
    {
        return health;
    }
}
