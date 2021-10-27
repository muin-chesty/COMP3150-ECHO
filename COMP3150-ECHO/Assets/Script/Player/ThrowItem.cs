using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public Camera cam;
    private HealthManager hp;
    private Vector2 lastMouseClick;
    public float speed = 10f;
    [SerializeField]
    private int ammoCount = 5;
    private int currentAmmoIndex = 0;

    [Space]
    public GameObject itemRippleEffect;
    private const int LEFT_CLICK = 0;
    private AnalyticsManager analytics;
    private bool tutorial;

    private TutorialSetting config;

    public int GetAmmoCount()
    {
        return ammoCount - currentAmmoIndex;
    }

    [Space]
    public ItemMove rock;

    private void Start()
    {
        hp = GetComponent<HealthManager>();
        analytics = FindObjectOfType<AnalyticsManager>();

        config = FindObjectOfType<TutorialSetting>();

        if (config != null)
        {
            tutorial = config.isTutorial();
        }
        else
        {
            tutorial = false;
        }
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        // IF LEFT-MOUSE CLICKED
        if (Input.GetMouseButtonDown(LEFT_CLICK))
        {
            // CHECK IF HAS AMMO
            if (currentAmmoIndex < ammoCount && hp.GetHealth() > 0)
            {
                SpawnThrowable();
                // COUNT FOR AN AMMO
                currentAmmoIndex++;
                analytics.IncrementThrowablesUsed();
            }
            else if (tutorial)
            {
                SpawnThrowable();
            }
            else
            {
                analytics.ThrowablesDepleted();
            }
        }
    }

    void SpawnThrowable()
    {
        ItemMove temp = Instantiate(rock);
        temp.transform.position = transform.position;
        lastMouseClick = cam.ScreenToWorldPoint(Input.mousePosition);
        temp.SetTarget(lastMouseClick);
    }
}
