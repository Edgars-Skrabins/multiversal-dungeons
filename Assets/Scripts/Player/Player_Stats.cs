using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player_Stats : MonoBehaviour
{
    public int m_playerID {get; set;}

    [Header("Player Movement")]

    [field: SerializeField] public float m_playerMoveSpeed;
    [Space(5)]
    
    [Header("Player Components")]

    [field: SerializeField] public Rigidbody2D m_playerRB;

    [field: SerializeField] public Transform PlayerTF;

    private void SetPlayerTF(Transform _tf)
    {
        PlayerTF = _tf;
    }

    public Transform GetPlayerTF()
    {
        return PlayerTF;
    }

    [field: SerializeField] public Player_WeaponManager m_weaponManagerCS;

    private void Awake()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        m_playerRB = GetComponent<Rigidbody2D>();
        PlayerTF = GetComponent<Transform>();
        m_weaponManagerCS = GetComponent<Player_WeaponManager>();

        SetPlayerTF(GetComponent<Transform>());
    }

}
