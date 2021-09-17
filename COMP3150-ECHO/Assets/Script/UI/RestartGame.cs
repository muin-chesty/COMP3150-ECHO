using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public HealthManager hp;
    public void RestartWholeGame()
    {
        hp.SetHealth(5);
        TransitionPlayer.instance = null;   // TO RESET THE START TRANSITION
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
