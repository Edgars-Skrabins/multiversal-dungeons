using UnityEngine;

public class Player_AnimationController : MonoBehaviour
{
    [SerializeField] private Animator m_playerAnimator;

    private void Update()
    {
        SetFacingDirection();
        SetSpeed();
    }

    private void SetFacingDirection()
    {
        Vector2 mousePosition = InputManager.I.GetWorldMousePosition();
        Vector2 direction = mousePosition - (Vector2)transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float horizontalAnimParam = 0f;
        float verticalAnimParam = 0f;

        // Determine the facing direction based on the angle
        switch (angle)
        {
            case >= 0f and <= 45f:
                // Up Right
                horizontalAnimParam = 1f;
                verticalAnimParam = 1f;
                break;
            case > 45f and <= 135f:
                // Up
                verticalAnimParam = 1f;
                horizontalAnimParam = 0f;
                break;
            case > 135f and <= 180f:
                // Up Left
                verticalAnimParam = 1f;
                horizontalAnimParam = -1f;
                break;
            case < 0f and >= -45:
                // Down Right
                horizontalAnimParam = 1f;
                verticalAnimParam = -1f;
                break;
            case < -45f and >= -135f:
                // Down
                verticalAnimParam = -1f;
                horizontalAnimParam = 0f;
                break;
            case < -135f and >= -180f:
                // Down Left
                verticalAnimParam = -1f;
                horizontalAnimParam = -1f;
                break;
        }

        // Update animator parameters for facing direction only
        m_playerAnimator.SetFloat("Horizontal", horizontalAnimParam);
        m_playerAnimator.SetFloat("Vertical", verticalAnimParam);
    }

    private void SetSpeed()
    {
        m_playerAnimator.SetFloat("Speed", InputManager.I.GetMovementVector2Normalized().magnitude);
    }
}
