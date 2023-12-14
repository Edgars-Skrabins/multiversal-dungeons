using System;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{

    [Header("Player Movement")]

    [field: SerializeField] public float m_playerMoveSpeed;
    [Space(5)]
    
    [Header("Player Components")]

    [field: SerializeField] public Rigidbody2D m_playerRB;

    [field: SerializeField] public Transform m_playerTF;

    [field: SerializeField] public Player_WeaponManager m_weaponManagerCS;

    private void Awake()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        m_playerRB = GetComponent<Rigidbody2D>();
        m_playerTF = GetComponent<Transform>();
        m_weaponManagerCS = GetComponent<Player_WeaponManager>();
    }
}
