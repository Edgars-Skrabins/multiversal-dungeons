using System.Collections.Generic;
using MultiversalDungeons.Utilities;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    [Header("Player spawn settings")]
    [Space(5)]
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private Transform m_playerSpawnPointTF;
    [SerializeField] private List<Player_Stats> m_players;

    private void Start()
    {
        InitializeGame();
        Utilities.Initialize();
    }

    private void InitializeGame()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(m_playerPrefab, m_playerSpawnPointTF.position, m_playerSpawnPointTF.rotation);
        if(player.TryGetComponent(out Player_Stats playerStatsCS))
        {
            m_players.Add(playerStatsCS);
        }
    }

    public Transform GetPlayerTransform()
    {
        return m_players[0].m_playerTF;
    }
}