using UnityEngine;
using MultiversalDungeons.Utilities;

public class GameManager : Singleton<GameManager>
{
    
    [Header("Player spawn settings")]
    [Space(5)]
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private Transform m_playerSpawnPointTF;

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
        Instantiate(m_playerPrefab, m_playerSpawnPointTF.position, m_playerSpawnPointTF.rotation);
    }
}