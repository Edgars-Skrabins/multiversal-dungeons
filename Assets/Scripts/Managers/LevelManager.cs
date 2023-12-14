using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_rooms;
    [SerializeField] private GameObject m_portal;
    [SerializeField] private bool m_defeatedAllEnemies;


    private bool _roomCompleted;
    private GameObject _currentRoom;
    private int _currentRoomIndex;  

    private void Start()
    {
        InitializeRooms();
    }

    private void InitializeRooms()
    {
        _currentRoomIndex = 0;
        ActivateCurrentRoom(_currentRoomIndex);
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
        _roomCompleted = true;
        CreatePortal();
    }

    private void CreatePortal()
    {
        Instantiate(m_portal, _currentRoom.GetComponent<RoomManager>().m_PortalSpawnPoint);
    }

    public void GoToNextRoom()
    {
        _roomCompleted = false;
        _currentRoom.SetActive(false);

        if ((_currentRoomIndex + 1) < m_rooms.Length)
        {
            _currentRoomIndex += 1;
            ActivateCurrentRoom(_currentRoomIndex);
        }
        else
        {
            Debug.Log("You have reached the end of this Level, Congrats!!! ");
        }

    }

    private void ActivateCurrentRoom(int _room)
    {
        // _room -> the room index you want to activate

        _currentRoom = m_rooms[_room].gameObject;
        _currentRoom.SetActive(true);
        GameManager.I.GetPlayerTransform().position = _currentRoom.GetComponent<RoomManager>().m_PlayerSpawnPoint.position;
    }

}
