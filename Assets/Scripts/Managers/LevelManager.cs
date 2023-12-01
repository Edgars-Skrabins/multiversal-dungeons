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
        _currentRoom = m_rooms[_currentRoomIndex].gameObject;
        _currentRoom.SetActive(true);
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
        Instantiate(m_portal);
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        Debug.Log("Entered Trigger");
        if (_other.tag == "Portal")
        {
            Debug.Log("Entered Portal");
            GoToNextRoom();
        }
    }

    public void GoToNextRoom()
    {
        _roomCompleted = false;
        _currentRoom.SetActive(false);
        _currentRoomIndex += 1;
        _currentRoom = m_rooms[_currentRoomIndex].gameObject;
        _currentRoom.SetActive(true);
    }

}
