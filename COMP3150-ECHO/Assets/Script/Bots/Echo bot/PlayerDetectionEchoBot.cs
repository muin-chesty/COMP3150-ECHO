using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetectionEchoBot : MonoBehaviour
{
    private TutorialSetting config;
    private bool tutorial;

    // Start is called before the first frame update
    void Start()
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


    private void OnParticleCollision(GameObject other)
    {
        if (!tutorial)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
