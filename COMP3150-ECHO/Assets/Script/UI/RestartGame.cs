using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartWholeGame()
    {
        TransitionPlayer.instance = null;   // TO RESET THE START TRANSITION
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
