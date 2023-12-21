using UnityEngine;

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


    [SerializeField] private GameObject m_portal;
    [SerializeField] private bool m_defeatedAllEnemies;


    private bool m_roomCompleted;
    private GameObject m_currentRoom;
    private int m_currentRoomIndex;

    private void Start()
    {
        InitializeRooms();
    }

    private void InitializeRooms()
    {
        m_currentRoomIndex = Random.Range(0, m_rooms_small.Length - 1);
        ActivateCurrentRoom(m_rooms_small, m_currentRoomIndex);
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


        if (m_currentRoomIndex + 1 < m_rooms_small.Length)
        {
            m_currentRoomIndex += 1;
            ActivateCurrentRoom(m_rooms_small, m_currentRoomIndex);
        }
        else
        {
            // TODO: Level finish implementation
            Debug.Log("You have reached the end of this Level, Congrats!!! ");
        }

    }

    private void ActivateCurrentRoom(GameObject[] _rooms_remaining, int _room)
    {
        // _room -> the room index you want to activate

        m_currentRoom = _rooms_remaining[_room].gameObject;
        m_currentRoom.SetActive(true);

        GameManager.I.GetPlayerTransform().position = m_currentRoom.GetComponent<RoomManager>().m_PlayerSpawnPoint.position;
    }

}
