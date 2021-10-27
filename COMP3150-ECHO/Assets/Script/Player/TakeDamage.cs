using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private HealthManagerV2 hp;
    private CameraRotate cameraDetection;
    void Start()
    {
        hp = FindObjectOfType<HealthManagerV2>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hp.ReduceHealth(other);
        cameraDetection = other.GetComponentInParent<CameraRotate>();
        if (cameraDetection != null)
        {
            cameraDetection.Detected(true);
        }
    }
}
