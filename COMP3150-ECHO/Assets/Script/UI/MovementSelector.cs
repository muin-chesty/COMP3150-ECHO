using UnityEngine;

public class MovementSelector : MonoBehaviour
{
    [SerializeField]
    private Movement movement;
    [SerializeField]
    private MouseMovement mouseMovement;
    [SerializeField]
    private SmoothMouseMovement smoothMouseMovement;

    private void Awake()
    {
        EnableWASD();
    }
    public void EnableWASD()
    {
        movement.enabled = true;
        mouseMovement.enabled = false;
        smoothMouseMovement.enabled = false;
        
    }

    public void EnableMouseMovement()
    {
        movement.enabled = false;
        mouseMovement.enabled = true;
        smoothMouseMovement.enabled = false;
        transform.Translate(Vector3.zero);
    }

    public void EnableSmoothMouseMovement()
    {
        movement.enabled = false;
        mouseMovement.enabled = false;
        smoothMouseMovement.enabled = true;
        transform.Translate(Vector3.zero);
    }
}
