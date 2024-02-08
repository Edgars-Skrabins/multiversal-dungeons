using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform m_PlayerSpawnPoint;
    public Transform m_PortalSpawnPoint;
    public Transform[] m_EnemySpawnPoints;
    public enum Rooms { small, medium, large, boss }
    public Rooms m_roomType;
    public int m_MaxEnemies;

}
