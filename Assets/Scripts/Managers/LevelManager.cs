using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using NavMeshPlus;

public class LevelManager : MonoBehaviour
{
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


    [Header(" ----- Playable Rooms ----- ")]
    [SerializeField] private GameObject m_navMesh;

    [SerializeField] private GameObject m_portal;
    [SerializeField] private bool m_defeatedAllEnemies;


    public GameObject m_currentRoom;
    private bool m_roomCompleted;
    private int m_currentRoomIndex;

    private void Start()
    {
        InitializeRooms();
    }

    private void InitializeRooms()
    {
        // randomly get some rooms from each type
        //get 3 small rooms
        for (int i = 0; i < 3; i++)
        {
            int _randomNumber = Random.Range(0, m_rooms_small.Length - 1);

            if (!m_rooms_playable.Contains(m_rooms_small[_randomNumber]))
            {
                m_rooms_playable.Add(m_rooms_small[_randomNumber]);
            }
        }
        //get 3 medium rooms
        for (int j = 0; j < 3; j++)
        {
            int _randomNumber = Random.Range(0, m_rooms_medium.Length - 1);

            if (!m_rooms_playable.Contains(m_rooms_medium[_randomNumber]))
            {
                m_rooms_playable.Add(m_rooms_medium[_randomNumber]);
            }
        }
        //get 2 large rooms
        for (int k = 0; k < 2; k++)
        {
            int _randomNumber = Random.Range(0, m_rooms_large.Length - 1);

            if (!m_rooms_playable.Contains(m_rooms_large[_randomNumber]))
            {
                m_rooms_playable.Add(m_rooms_large[_randomNumber]);
            }
        }
        //get 1 boss room
        m_rooms_playable.Add(m_rooms_boss[Random.Range(0, m_rooms_boss.Length - 1)]);

        m_currentRoomIndex = 0;
        ActivateCurrentRoom(m_rooms_playable, m_currentRoomIndex);
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
        m_currentRoom.SetActive(false);


        // check size of current room

        // check how many more of that size rooms the player has completed


        if (m_currentRoomIndex + 1 < m_rooms_playable.Count)
        {
            m_currentRoomIndex += 1;
            ActivateCurrentRoom(m_rooms_playable, m_currentRoomIndex);
        }
        else
        {
            // TODO: Level finish implementation
            Debug.Log("You have reached the end of this Level, Congrats!!! ");
        }

    }

    private void ActivateCurrentRoom(List<GameObject> _rooms_remaining, int _room)
    {
        // _room -> the room index you want to activate

        m_currentRoom = _rooms_remaining[_room].gameObject;
        m_currentRoom.SetActive(true);

        m_navMesh.GetComponent<NavMeshPlus.Components.NavMeshSurface>().BuildNavMeshAsync();

        GameManager.I.GetPlayerTransform().position = m_currentRoom.GetComponent<RoomManager>().m_PlayerSpawnPoint.position;
    }

}
