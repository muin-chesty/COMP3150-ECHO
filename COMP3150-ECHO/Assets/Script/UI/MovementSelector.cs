using UnityEngine;

public class MovementSelector : MonoBehaviour
{
    [SerializeField]
    private Movement movement;
    [SerializeField]
    private MouseMovement mouseMovement;
    [SerializeField]
    private SmoothMouseMovement smoothMouseMovement;
    [SerializeField]
    private DirectionalMovemet directionalMovemet;

    private void Awake()
    {
        EnableWASD();
    }
    public void EnableWASD()
    {
        movement.enabled = true;
        mouseMovement.enabled = false;
        smoothMouseMovement.enabled = false;
        directionalMovemet.enabled = false;
        
    }

    public void EnableMouseMovement()
    {
        movement.enabled = false;
        mouseMovement.enabled = true;
        smoothMouseMovement.enabled = false;
        directionalMovemet.enabled = false;
    }

    public void EnableSmoothMouseMovement()
    {
        movement.enabled = false;
        mouseMovement.enabled = false;
        smoothMouseMovement.enabled = true;
        directionalMovemet.enabled = false;
    }

    public void EnableDirectionalMovement()
    {
        movement.enabled = false;
        mouseMovement.enabled = false;
        smoothMouseMovement.enabled = false;
        directionalMovemet.enabled = true;
    }
}
