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

    private Transform m_SpawnPointTF;

    public void SpawnEnemy(int _numberOfEnemies)
    {
        Transform[] _possibleSpawnPoints = m_levelManagerSC.m_currentRoom.GetComponent<RoomManager>().m_EnemySpawnPoints;
        List<Transform> m_spawnPoint = new List<Transform>();

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            int _randomNumber = Random.Range(0, _possibleSpawnPoints.Length - 1);
            Debug.Log(_randomNumber);
            if (!m_spawnPoint.Contains(_possibleSpawnPoints[_randomNumber]))
            {
                m_SpawnPointTF = _possibleSpawnPoints[_randomNumber];
                m_spawnPoint.Add(_possibleSpawnPoints[_randomNumber]);
                Instantiate(m_enemyType_1GO, m_SpawnPointTF);
            }
        }
    }

}


