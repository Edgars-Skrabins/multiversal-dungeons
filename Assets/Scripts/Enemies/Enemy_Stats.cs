using UnityEngine;
using UnityEngine.UI;

public class Enemy_Stats : MonoBehaviour
{
    [Header("Enemy Movement")]

    public float m_enemyMoveSpeed;

    [Header("Enemy Detection Range")]

    public float m_enemyRange = 2.5f;

    [Header("Enemy Health")]
    [SerializeField] private Enemy_Health m_healthCS;

    [Header("Enemy UI")]
    [SerializeField] private Slider m_healthSlider;

    private void Awake()
    {
        m_healthSlider.maxValue = m_healthCS.GetMaxHealthValue();
    }

    private void LateUpdate()
    {
        m_healthSlider.value = m_healthCS.GetCurrentHealthValue();
    }
}
