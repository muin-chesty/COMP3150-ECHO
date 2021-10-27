using UnityEngine;


public class TakeDamage : MonoBehaviour
{
    private HealthManagerV2 hp;
    void Start()
    {
        hp = FindObjectOfType<HealthManagerV2>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hp.ReduceHealth(other);
    }
}
