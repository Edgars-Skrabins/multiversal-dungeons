using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_rooms;
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
        m_currentRoomIndex = 0;
        ActivateCurrentRoom(m_currentRoomIndex);
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

        if (m_currentRoomIndex + 1 < m_rooms.Length)
        {
            m_currentRoomIndex += 1;
            ActivateCurrentRoom(m_currentRoomIndex);
        }
        else
        {
            // TODO: Level finish implementation
            Debug.Log("You have reached the end of this Level, Congrats!!! ");
        }

    }

    private void ActivateCurrentRoom(int _room)
    {
        // _room -> the room index you want to activate

        m_currentRoom = m_rooms[_room].gameObject;
        m_currentRoom.SetActive(true);

        GameManager.I.GetPlayerTransform().position = m_currentRoom.GetComponent<RoomManager>().m_PlayerSpawnPoint.position;
    }

}
