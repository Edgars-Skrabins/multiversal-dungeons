using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WeaponMovementController : MonoBehaviour
{
    [SerializeField] private Player_Stats m_playerStatsCS;

    [SerializeField] private Transform m_playerHandTF;

    [SerializeField] private Vector2 m_handPositionUp, m_handPositionUpRight, m_handPositionRight, m_handPositionDownRight, m_handPositionDown,
                                        m_handPositionDownLeft, m_handPositionLeft, m_handPositionUpLeft;

    private void Start()
    {
        if (m_playerStatsCS == null)
            m_playerStatsCS = GetComponent<Player_Stats>();
    }

    private void Update()
    {
        HandleHandPosition();        
    }

    void HandleHandPosition()
    {
        switch (m_playerStatsCS.m_playerFacingDirection)
        {
            case Player_Stats.FaceDirections.Up:
                m_playerHandTF.localPosition = m_handPositionUp;
                break;
            case Player_Stats.FaceDirections.UpRight:
                m_playerHandTF.localPosition = m_handPositionUpRight;
                break;
            case Player_Stats.FaceDirections.Right:
                m_playerHandTF.localPosition = m_handPositionRight;
                break;
            case Player_Stats.FaceDirections.DownRight:
                m_playerHandTF.localPosition = m_handPositionDownRight;
                break;
            case Player_Stats.FaceDirections.Down:
                m_playerHandTF.localPosition = m_handPositionDown;
                break;
            case Player_Stats.FaceDirections.DownLeft:
                m_playerHandTF.localPosition = m_handPositionDownLeft;
                break;
            case Player_Stats.FaceDirections.Left:
                m_playerHandTF.localPosition = m_handPositionLeft;
                break;
            case Player_Stats.FaceDirections.UpLeft:
                m_playerHandTF.localPosition = m_handPositionUpLeft;
                break;
            default:
                break;
        }
    }
}
