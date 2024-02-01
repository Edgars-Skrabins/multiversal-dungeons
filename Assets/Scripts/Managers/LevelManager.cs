using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using NavMeshPlus.Components;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header(" ----- Managers ----- ")]
    [SerializeField] private EnemyManager m_enemyManager;

    [Header(" ----- Small Rooms ----- ")]
    [SerializeField] private GameObject[] m_rooms_small;
    [Header(" ----- Medium Rooms ----- ")]
    [SerializeField] private GameObject[] m_rooms_medium;
    [Header(" ----- Large Rooms ----- ")]
    [SerializeField] private GameObject[] m_rooms_large;
    [Header(" ----- Boss Rooms ----- ")]
    [SerializeField] private GameObject[] m_rooms_boss;

    [Header(" ----- Playable Rooms ----- ")]
    [SerializeField] private List<GameObject> m_rooms_playable = new List<GameObject>();


    [Header(" ----- NavMesh ----- ")]
    [SerializeField] private NavMeshSurface m_navMesh;

    [Header(" ----- Level Logic ----- ")]
    [SerializeField] private GameObject m_portal;
    [SerializeField] private bool m_defeatedAllEnemies;
    public RoomManager m_currentRoom;
    private int m_currentRoomIndex;
    private bool m_roomCompleted;




    private void Start()
    {
        InitializeRooms();
    }

    private void InitializeRooms()
    {
        // randomly get some rooms from each type
        //get 3 small rooms
        for (int i = 0;m_rooms_playable.Count < 3; i++)
        {
            int _randomNumber = Random.Range(0, m_rooms_small.Length - 1);

            if (!m_rooms_playable.Contains(m_rooms_small[_randomNumber]))
            {
                m_rooms_playable.Add(m_rooms_small[_randomNumber]);
            }
            else
            {
                int _newRandomNumber = Random.Range(0, m_rooms_small.Length - 1);
                if(_newRandomNumber != _randomNumber)
                    m_rooms_playable.Add(m_rooms_small[_newRandomNumber]);
            }
        }
        //get 3 medium rooms
        for (int j = 0; m_rooms_playable.Count < 6; j++)
        {
            int _randomNumber = Random.Range(0, m_rooms_medium.Length - 1);

            if (!m_rooms_playable.Contains(m_rooms_medium[_randomNumber]))
            {
                m_rooms_playable.Add(m_rooms_medium[_randomNumber]);
            }
            else
            {
                int _newRandomNumber = Random.Range(0, m_rooms_medium.Length - 1);
                if (_newRandomNumber != _randomNumber)
                    m_rooms_playable.Add(m_rooms_medium[_newRandomNumber]);
            }
        }
        //get 2 large rooms
        for (int k = 0; m_rooms_playable.Count < 8; k++)
        {
            int _randomNumber = Random.Range(0, m_rooms_large.Length - 1);

            if (!m_rooms_playable.Contains(m_rooms_large[_randomNumber]))
            {
                m_rooms_playable.Add(m_rooms_large[_randomNumber]);
            }
            else
            {
                int _newRandomNumber = Random.Range(0, m_rooms_large.Length - 1);
                if (_newRandomNumber != _randomNumber)
                    m_rooms_playable.Add(m_rooms_large[_newRandomNumber]);
            }
        }
        //get 1 boss room
        m_rooms_playable.Add(m_rooms_boss[Random.Range(0, m_rooms_boss.Length - 1)]);

        GameObject playableRooms = new GameObject("Playable_Rooms");
        List<GameObject> instantiatedRooms = new List<GameObject>();
        //Instantiate Playable Rooms
        for (int i = 0; i < m_rooms_playable.Count; i++)
        {
            GameObject room = m_rooms_playable[i];
            GameObject _room = Instantiate(room, playableRooms.transform);
            _room.SetActive(false);
            instantiatedRooms.Add(_room);
        }
        m_rooms_playable.Clear();
        m_rooms_playable = instantiatedRooms;

        m_currentRoomIndex = 0;
        m_rooms_playable[m_currentRoomIndex].SetActive(true);
        ActivateCurrentRoom();
    }

    private void Update()
    {
        if (m_defeatedAllEnemies)
        {
            AfterDefeatAllEnemies();
        }
    }

    private void AfterDefeatAllEnemies()
    {
        m_defeatedAllEnemies = false;
        m_roomCompleted = true;
        CreatePortal();
    }

    private void CreatePortal()
    {
        Instantiate(m_portal, m_currentRoom.GetComponent<RoomManager>().m_PortalSpawnPoint);
    }

    public void GoToNextRoom()
    {
        m_roomCompleted = false;
        m_currentRoom.gameObject.SetActive(false);


        // check size of current room

        // check how many more of that size rooms the player has completed


        if (m_currentRoomIndex + 1 < m_rooms_playable.Count)
        {
            m_currentRoomIndex += 1;
            ActivateCurrentRoom();
        }
        else
        {
            // TODO: Level finish implementation
            Debug.Log("You have reached the end of this Level, Congrats!!! ");
        }

    }

    private void ActivateCurrentRoom()
    {
        // _room -> the room index you want to activate

        m_currentRoom = m_rooms_playable[m_currentRoomIndex].GetComponent<RoomManager>();
        m_currentRoom.gameObject.SetActive(true);

        GameManager.I.GetPlayerTransform().position = m_currentRoom.m_PlayerSpawnPoint.position;
        
        m_navMesh.BuildNavMeshAsync();

        if (m_enemyManager)
        {
            m_enemyManager.SpawnEnemy(4);
        }
    }

}
