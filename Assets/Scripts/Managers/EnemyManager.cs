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

    private List<GameObject> m_spawnedEnemies;

    public void SpawnEnemy(int _numberOfEnemies)
    {
        List<GameObject> m_levelEnemies = new List<GameObject>();
        Transform[] possibleSpawnPoints = m_levelManagerSC.m_currentRoom.m_EnemySpawnPoints;

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            foreach (var tf in possibleSpawnPoints)
            {
                if(m_levelEnemies.Count < _numberOfEnemies)
                    m_levelEnemies.Add(Instantiate(m_enemyType_1GO, tf));
            }
        }

        m_spawnedEnemies = m_levelEnemies;
        /*
        List<Transform> spawnPoints = new List<Transform>();

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            int _randomNumber = Random.Range(0, possibleSpawnPoints.Length - 1);
            if (!spawnPoints.Contains(possibleSpawnPoints[_randomNumber]))
            {
                m_SpawnPointTF = possibleSpawnPoints[_randomNumber];
                spawnPoints.Add(possibleSpawnPoints[_randomNumber]);
                Debug.Log(m_SpawnPointTF.name);
                Debug.Log(m_SpawnPointTF.position);
                Instantiate(m_enemyType_1GO, m_SpawnPointTF);
            }
        }
        */
    }

    private void LateUpdate()
    {
        TrackSpawnedEnemies();
    }

    private void TrackSpawnedEnemies()
    {
        for (int i = 0; i < m_spawnedEnemies.Count; i++)
        {
            if (m_spawnedEnemies[i] == null)
            {
                m_spawnedEnemies.RemoveAt(i);
            }
        }
    }

    public int GetSpawnedEnemyCount()
    {
        return m_spawnedEnemies.Count;
    }
}


