using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] GameObject[] _rooms;
    [SerializeField] GameObject _portal;
    [SerializeField] bool _defeatedAllEnemies = false;
    private bool _roomCompleted = false;
    private GameObject _currentRoom;
    private int _currentRoomIndex;

    // Start is called before the first frame update
    void Start()
    {
        _currentRoomIndex = 0;
        _currentRoom = _rooms[_currentRoomIndex].gameObject;
        _currentRoom.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_defeatedAllEnemies)
        {
            AfterDefeatAllEnemies();
        }
        
    }

    private void AfterDefeatAllEnemies()
    {
        _defeatedAllEnemies = false;
        _roomCompleted = true;
        CreatePortal();
    }

    private void CreatePortal()
    {
        Instantiate(_portal);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Trigger");
        if (other.tag == "Portal")
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
        _currentRoom = _rooms[_currentRoomIndex].gameObject;
        _currentRoom.SetActive(true);
    }

    
}
