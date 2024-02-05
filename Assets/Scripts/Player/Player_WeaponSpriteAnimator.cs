using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WeaponSpriteAnimator : MonoBehaviour
{
    [SerializeField] private Player_Stats m_stats;
    [Header("Gun Sprites")]
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private Sprite m_upSprite, m_upRightSprite, m_upLeftSprite,
        m_downSprite, m_downRightSprite, m_downLeftSprite, m_rightSprite, m_leftSprite;

    private void Update()
    {
        UpdateGunSprite();
    }

    private void UpdateGunSprite()
    {
        switch (m_stats.m_playerFacingDirection)
        {
            case Player_Stats.FaceDirections.Up:
                ChangeSprite(m_upSprite,0);
                break;
            case Player_Stats.FaceDirections.UpRight:
                ChangeSprite(m_upRightSprite, 0);
                break;
            case Player_Stats.FaceDirections.Right:
                ChangeSprite(m_rightSprite, 0);
                break;
            case Player_Stats.FaceDirections.DownRight:
                ChangeSprite(m_downRightSprite, 0);
                break;
            case Player_Stats.FaceDirections.Down:
                ChangeSprite(m_downSprite, 0);
                break;
            case Player_Stats.FaceDirections.DownLeft:
                ChangeSprite(m_downSprite, 0);
                break;
            case Player_Stats.FaceDirections.Left:
                ChangeSprite(m_leftSprite,0);
                break;
            case Player_Stats.FaceDirections.UpLeft:
                ChangeSprite(m_upLeftSprite, 0);
                break;
            default:
                break;
        }
    }

    private void ChangeSprite(Sprite _sprite, int _order)
    {
        if (_sprite == null)
            return;

        m_spriteRenderer.sprite = _sprite;
        m_spriteRenderer.sortingOrder = _order;
    }
}
