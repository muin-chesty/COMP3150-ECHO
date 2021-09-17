using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlayer : MonoBehaviour
{

    [Header("The opening Transition Canvas")]
    [SerializeField]
    public GameObject canvas;

    public static TransitionPlayer instance;

    private void Awake()
    {
        if (instance != null)
        {
            canvas.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            canvas.SetActive(false);
            DontDestroyOnLoad(gameObject);
        }
    }

  


}
