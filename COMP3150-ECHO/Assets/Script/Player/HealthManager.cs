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

    public Text healthText;


    private void Update()
    {
        healthText.text = "Health: " + HealthManager.health;
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
 
}
