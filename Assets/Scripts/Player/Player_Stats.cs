using UnityEngine;

public class Player_Stats : MonoBehaviour
{

    [Header("Player Movement")]
    [Space(5)]
    [field: SerializeField] public float m_playerMoveSpeed;
    [Space(5)]
    
    [Header("Player Components")]
    [field: SerializeField] public Rigidbody2D m_playerRB;

}
