using UnityEngine;

public class Player_Stats : MonoBehaviour
{

    [Header("Player Movement")]
    [field: SerializeField] public float m_playerMoveSpeed;
    [Space(5)]
    
    [Header("Player Components")]
    [field: SerializeField] public Rigidbody2D m_playerRB;
    public Player_WeaponManager m_playerWM;
    
}
