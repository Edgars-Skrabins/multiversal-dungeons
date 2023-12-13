using UnityEngine;

public class Player_AnimationController : MonoBehaviour
{
    [SerializeField] private Animator m_playerAnimator;


    private void Update()
    {
        SetFacingDirection();
        SetSpeed();
    }

    void SetFacingDirection()
    {
        Vector2 mousePosition = InputManager.I.GetWorldMousePosition();
        Vector2 direction = mousePosition - (Vector2)transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float horizontal = 0f;
        float vertical = 0f;

        // Determine the facing direction based on the angle
        if (angle >= 0f && angle <= 45f)
        {
            // Up Right
            horizontal = 1f; 
            vertical = 1f;
        }
        else if (angle > 45f && angle <= 135f)
        {
            // Up
            vertical = 1f; 
            horizontal = 0f;
        }
        else if (angle > 135f && angle <= 180f)
        {
            // Up Left
            vertical = 1f;
            horizontal = -1f;
        }

        else if(angle < 0f && angle >= -45)
        {
            // Down Right
            horizontal = 1f;
            vertical = -1f;
        }
        else if (angle < -45f && angle >= -135f)
        {
            // Down
            vertical = -1f;
            horizontal = 0f;
        }
        else if (angle < -135f && angle >= -180f)
        {
            // Down Left
            vertical = -1f;
            horizontal = -1f;
        }
        Debug.Log("Direction = " + angle);
        // Update animator parameters for facing direction only
        m_playerAnimator.SetFloat("Horizontal", horizontal);
        m_playerAnimator.SetFloat("Vertical", vertical);
    }

    private void SetSpeed()
    {
        m_playerAnimator.SetFloat("Speed", InputManager.I.GetMovementVector2Normalized().magnitude);
    }
}
