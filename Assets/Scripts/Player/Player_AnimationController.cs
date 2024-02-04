using UnityEngine;

public class Player_AnimationController : MonoBehaviour
{
    [SerializeField] private Player_Stats m_playerStatsCS;

    [SerializeField] private Animator m_playerAnimator;

    [SerializeField] private Transform[] m_playerArmsTF, m_playerGunsTF;
    [SerializeField] private Transform m_aimTarget;
    [SerializeField] private float m_armRotationOffset = -45f;

    private void Update()
    {
        SetFacingDirection();
        SetSpeed();
        HandleArmRotation();
    }
    private void HandleGunRotation(float _angle)
    {
        foreach (Transform gun in m_playerGunsTF)
        {
            //gun.LookAt(InputManager.I.GetWorldMousePosition());
            gun.rotation = Quaternion.Euler(0f, 0f, _angle);
        }
    }

    private void SetArmRotation(float _angle)
    {
        foreach (Transform arm in m_playerArmsTF)
        {
            arm.rotation = Quaternion.Euler(0f, 0f, _angle);
        }
    }

    private void HandleArmRotation()
    {
        switch (m_playerStatsCS.m_playerFacingDirection)
        {
            case Player_Stats.FaceDirections.Up:
                SetArmRotation(90f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.UpRight:
                SetArmRotation(45f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.Right:
                SetArmRotation(0f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.DownRight:
                SetArmRotation(-45f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.Down:
                SetArmRotation(-90f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.DownLeft:
                SetArmRotation(-135f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.Left:
                SetArmRotation(180f + m_armRotationOffset);
                break;
            case Player_Stats.FaceDirections.UpLeft:
                SetArmRotation(135f + m_armRotationOffset);
                break;
            default:
                break;
        }
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
        if (angle >= -22.5f && angle < 22.5f)
        {
            // Right
            horizontalAnimParam = 1f;
            verticalAnimParam = 0f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.Right;
        }
        else if (angle >= 22.5f && angle < 67.5f)
        {
            // Up Right
            horizontalAnimParam = 1f;
            verticalAnimParam = 1f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.UpRight;
        }
        else if (angle >= 67.5f && angle < 112.5f)
        {
            // Up
            horizontalAnimParam = 0f;
            verticalAnimParam = 1f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.Up;
        }
        else if (angle >= 112.5f && angle < 157.5f)
        {
            // Up Left
            horizontalAnimParam = -1f;
            verticalAnimParam = 1f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.UpLeft;
        }
        else if ((angle >= 157.5f && angle <= 180f) || (angle >= -180f && angle < -157.5f))
        {
            // Left
            horizontalAnimParam = -1f;
            verticalAnimParam = 0f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.Left;
        }
        else if (angle >= -157.5f && angle < -112.5f)
        {
            // Down Left
            horizontalAnimParam = -1f;
            verticalAnimParam = -1f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.DownLeft;
        }
        else if (angle >= -112.5f && angle < -67.5f)
        {
            // Down
            horizontalAnimParam = 0f;
            verticalAnimParam = -1f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.Down;
        }
        else if (angle >= -67.5f && angle < -22.5f)
        {
            // Down Right
            horizontalAnimParam = 1f;
            verticalAnimParam = -1f;
            m_playerStatsCS.m_playerFacingDirection = Player_Stats.FaceDirections.DownRight;
        }

        // Update animator parameters for facing direction only
        m_playerAnimator.SetFloat("Horizontal", horizontalAnimParam);
        m_playerAnimator.SetFloat("Vertical", verticalAnimParam);

        HandleGunRotation(angle + m_armRotationOffset);
    }

    private void SetSpeed()
    {
        m_playerAnimator.SetFloat("Speed", InputManager.I.GetMovementVector2Normalized().magnitude);
    }
}
