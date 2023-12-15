using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private Enemy_Stats m_enemyStatsCS;

    private Transform m_enemyTarget;
    private NavMeshAgent m_enemyAgent;

    private void Awake()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        m_enemyStatsCS = GetComponent<Enemy_Stats>();
        m_enemyAgent = GetComponent<NavMeshAgent>();

        m_enemyAgent.updateRotation = false;
        m_enemyAgent.updateUpAxis = false;
    }

    private void Update()
    {
            FollowPlayer();

        /*
        if (IsPlayerInDetectionRadius(GameManager.I.GetPlayerTransform()) && m_enemyTarget)
            FollowPlayer();
        else
            PatrolRandomly();
        */
    }

    private void FollowPlayer()
    {
        if(IsPlayerInDetectionRadius())
        {
            m_enemyAgent.SetDestination(m_enemyTarget.position);
        }
    }

    private void PatrolRandomly()
    {
        m_enemyAgent.SetDestination(Vector3.zero);
    }

    private bool IsPlayerInDetectionRadius()
    {
        float distance = Vector2.Distance(transform.position, GameManager.I.GetPlayerTransform().position);
        if (distance > m_enemyStatsCS.m_enemyRange)
        {
            m_enemyTarget = null;
            return false;
        }

        // Uses player to sets target
        m_enemyTarget = GameManager.I.GetPlayerTransform();
        return true;
    }
}
