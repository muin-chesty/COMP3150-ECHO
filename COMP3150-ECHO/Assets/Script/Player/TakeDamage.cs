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

    void Start()
    {
        isPlayerHit = false;
        hp = GetComponent<HealthManager>();
        analytics = FindObjectOfType<AnalyticsManager>();
    }

    void Update()
    {
        if (isPlayerHit == true)
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
    }
    public bool IsPlayerHit()
    {
        return isPlayerHit;
    }
    private void OnParticleCollision(GameObject other)
    {
        isPlayerHit = true;
        if (hp.GetHealth() > 1) // TO ENSURE DIE TRANSITION DOESN'T APPEAR WHEN GAME IS OVER
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
