using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    [SerializeField]
    private float restartsIn = 2f;
    private float timer = 0f;
    [SerializeField]
    private Canvas dieTransitionCanvas;
    private bool isPlayerAlive; // TO KEEP TRACK OF PLAYER'S ALIVE STATUS. IF PLAYER IS DEAD MOVEMENT CONTROL WOULD BE DISABLED

    private FinalMovement move;
    void Start()
    {
        isPlayerAlive = true;
        move = GetComponent<FinalMovement>();
    }

    
    void Update()
    {
        if(!isPlayerAlive)
        {
            timer += Time.deltaTime;
            if(timer >= restartsIn)
            {
                Time.timeScale = 1f;
                timer = 0f;
                isPlayerAlive = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public bool IsPlayerAlive()
    {
        return isPlayerAlive;
    }
    private void OnParticleCollision(GameObject other)
    {
        isPlayerAlive = false;
        Destroy(move);
        dieTransitionCanvas.gameObject.SetActive(true);
        Time.timeScale = 0.5f;
        
    }
}
