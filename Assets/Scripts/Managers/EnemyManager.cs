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

}


