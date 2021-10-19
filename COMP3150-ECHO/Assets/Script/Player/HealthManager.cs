using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private static int health = 5;
    private static bool isPlayerDead = false;
    [SerializeField]
    private GameObject gameoverCanvas;
    [SerializeField]
    private GameObject uiCanvas;

    private TutorialSetting config;
    private bool tutorial;
    public Text healthText;

    private void Start()
    {
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

    private void Update()
    {
        if (!tutorial)
        {
            healthText.text = "Health: " + HealthManager.health;
        }
        else
        {
            healthText.text = "Health: ∞";
        }
    }
    public bool IsPlayerDead()
    {
        return isPlayerDead;
    }
    public void TakeDamage(int num)
    {
        health -= num;
        if (health <= 0)
        {
            uiCanvas.SetActive(false);
            gameoverCanvas.SetActive(true);
            HealthManager.isPlayerDead = true;
            Destroy(GetComponent<SpriteRenderer>());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int health)
    {
        if(health > 0)
        {
            HealthManager.health = health;
        }
        
    }
    public void GainHealth(int health)
    {
        if(health > 0)
        {
            health++;
        }
    }
 
    public void TutorialModeDamage()
    {
        Camera.main.backgroundColor = Color.red;
    }

}
