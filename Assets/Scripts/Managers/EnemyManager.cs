using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject _enemyType_1;
    [SerializeField] GameObject _enemyType_2;
    [SerializeField] GameObject _enemyType_3;

    [SerializeField] LevelManager m_levelManager;
    private RoomManager m_roomManager;

    private void OnEnable()
    {

        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    private void Update()
    {

    }

    private void SpawnEnemy()
    {
        m_roomManager = m_levelManager.m_currentRoom.GetComponent<RoomManager>();
        Instantiate(_enemyType_1, m_roomManager.m_EnemySpawnPoints[Random.Range(0, m_roomManager.m_EnemySpawnPoints.Length - 1)]);
    }

}


