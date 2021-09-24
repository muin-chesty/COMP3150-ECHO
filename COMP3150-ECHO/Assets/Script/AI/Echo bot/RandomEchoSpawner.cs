using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEchoSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Drag in Particle system for Echo bot")]
    private GameObject ps;
    [Space]
    [SerializeField]
    private float maxRange = 5f;
    [SerializeField]
    private float minRange = 1f;
    private float timer = 0f;
    private float spawnAt = 2f;

    public GameObject lightObject;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnAt)
        {
            timer = 0f;
            GameObject temp = Instantiate(ps);
            temp.transform.position = transform.position;
            Destroy(temp, 3f);
            spawnAt = Random.Range(minRange, maxRange);
            if(lightObject != null)
            {
                lightObject.SetActive(true);
            }
            
            
        }

        
    }
}
