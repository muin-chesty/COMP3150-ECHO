using UnityEngine;


public class TakeDamage : MonoBehaviour
{
    [SerializeField]
    private float restartsIn = 2f;
    private float timer = 0f;
    [SerializeField]
    private Canvas dieTransitionCanvas;
    private bool isPlayerHit; // TO KEEP TRACK OF PLAYER'S ALIVE STATUS. IF PLAYER IS DEAD MOVEMENT CONTROL WOULD BE DISABLED

    private HealthManager hp;

    private AnalyticsManager analytics;

    private bool hit;

    private TutorialSetting config;
    private bool tutorial;

    void Start()
    {
        isPlayerHit = false;
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
        Camera.main.backgroundColor = Color.black;

        if (isPlayerHit == true)
        {
            if (!tutorial)
            {
                timer += Time.deltaTime;
                if (timer >= restartsIn)
                {
                    Time.timeScale = 1f;
                    timer = 0f;
                    isPlayerHit = false;
                    hp.TakeDamage(1);
                }
            }
            else
            {
                isPlayerHit = false;
                hp.TutorialModeDamage();
            }
        }
    }
    public bool IsPlayerHit()
    {
        return isPlayerHit;
    }

    private void OnParticleCollision(GameObject other)
    {
        isPlayerHit = true;
        if (hp.GetHealth() > 1 && !tutorial) // TO ENSURE DIE TRANSITION DOESN'T APPEAR WHEN GAME IS OVER
        {
            dieTransitionCanvas.gameObject.SetActive(true);
            Time.timeScale = 0.7f;

            if (!hit)
            {
                analytics.PlayerDead(other.gameObject.transform.parent.name);
                hit = true;
            }
        }

    }
}
