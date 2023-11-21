using UnityEngine;

public class Player_MoveControls : MonoBehaviour
{

    [SerializeField] private Player_Stats m_playerStatsCS;

    private Rigidbody2D m_playerRB;

    private void Awake()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        m_playerStatsCS = GetComponent<Player_Stats>();
        m_playerRB = m_playerStatsCS.m_playerRB;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movement = InputManager.I.GetMovementVector2Normalized();
        m_playerRB.velocity = movement * m_playerStatsCS.m_playerMoveSpeed;
    }
}
