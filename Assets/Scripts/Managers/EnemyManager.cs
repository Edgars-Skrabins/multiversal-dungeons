using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header(" ----- Managers ----- ")]
    [SerializeField] private LevelManager m_levelManagerSC;

    [Header(" ----- Enemy Types ----- ")]
    [SerializeField] private GameObject m_enemyType_1GO;
    [SerializeField] private GameObject m_enemyType_2GO;
    [SerializeField] private GameObject m_enemyType_3GO;

    private List<GameObject> m_currentSpawnedEnemies;
    private int m_spawnedEnemies;

    public void SpawnInitialEnemy()
    {
        m_spawnedEnemies = 0;
        List<GameObject> m_levelEnemies = new List<GameObject>();
        Transform[] possibleSpawnPoints = m_levelManagerSC.m_currentRoom.m_EnemySpawnPoints;
        int maxEnemiesAtATime = possibleSpawnPoints.Length;

        for (int i = 0; i < maxEnemiesAtATime; i++)
        {
            foreach (var tf in possibleSpawnPoints)
            {
                if (m_levelEnemies.Count < maxEnemiesAtATime)
                {
                    m_spawnedEnemies++;
                    m_levelEnemies.Add(Instantiate(m_enemyType_1GO, tf));
                }
            }
        }

        m_currentSpawnedEnemies = m_levelEnemies;
    }

    private void AddEnemy()
    {
        Transform[] possibleSpawnPoints = m_levelManagerSC.m_currentRoom.m_EnemySpawnPoints;
        int maxEnemiesAtATime = possibleSpawnPoints.Length;
        if (m_currentSpawnedEnemies.Count < maxEnemiesAtATime && m_spawnedEnemies < m_levelManagerSC.m_currentRoom.m_MaxEnemies)
        {
            m_spawnedEnemies++;
            int randomTFIndex = Random.Range(0, possibleSpawnPoints.Length);
            m_currentSpawnedEnemies.Add(Instantiate(m_enemyType_1GO, possibleSpawnPoints[randomTFIndex]));
        }
    }

    private void LateUpdate()
    {
        TrackSpawnedEnemies();
        AddEnemy();
    }

    private void TrackSpawnedEnemies()
    {
        for (int i = 0; i < m_currentSpawnedEnemies.Count; i++)
        {
            if (m_currentSpawnedEnemies[i] == null)
            {
                m_currentSpawnedEnemies.RemoveAt(i);
            }
        }
    }

    public int GetSpawnedEnemyCount()
    {
        return m_currentSpawnedEnemies.Count;
    }
}


