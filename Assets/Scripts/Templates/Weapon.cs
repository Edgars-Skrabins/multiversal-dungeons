using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] protected Player_Stats m_playerStatsCS;

    [Header("Weapon Settings")]
    [Space(5)]
    [SerializeField] protected float m_fireRateInSeconds;
    [SerializeField] protected Transform[] m_shootLocations;

    [Space(5)]
    [Header("Weapon VFX")]
    [Space(5)]
    [SerializeField] protected GameObject m_shotVFX;
    [SerializeField] protected Transform[] m_shotVFXLocations;
    [Space(5)]
    
    protected float m_fireRateTimer;
    protected bool m_fireRateZero;

    protected virtual void Awake()
    {
        SusbcribeToInputEvents();
    }

    protected virtual void Update()
    {
        CountFireRateTimer();
    }

    protected virtual void HandleShoot()
    {
        if(CanShoot()) Shoot();
    }

    protected virtual void Shoot()
    {
        ResetFireRateTimer();
        SpawnShotVFX();
    }

    protected virtual void SpawnShotVFX()
    {
        if(!m_shotVFX)
        {
            Debug.LogError("Weapon is missing Shot VFX!");
            return;
        }
        
        foreach(var tf in m_shotVFXLocations)
        {
            Instantiate(m_shotVFX, tf.position, tf.rotation);
        }
    }

    protected virtual bool CanShoot()
    {
        return m_fireRateZero && !IsShootLocationObstructed();
    }

    protected virtual bool IsShootLocationObstructed()
    {
        foreach(Transform tf in m_shootLocations)
        {
            // TODO: Make the logic for checking if fire location obstructed
            return true;
        }
        return false;
    }

    protected virtual void CountFireRateTimer()
    {
        if(m_fireRateTimer >= 0)
        {
            m_fireRateTimer -= Time.deltaTime;
        }

        m_fireRateZero = m_fireRateTimer <= 0 ? m_fireRateZero = true : m_fireRateZero = false;
    }

    protected virtual void ResetFireRateTimer()
    {
        m_fireRateTimer = m_fireRateInSeconds;
    }
    
    protected virtual void SusbcribeToInputEvents()
    {
        InputManager.I.OnShootPerformed += HandleShoot;
    }
    
    protected virtual void UnSusbcribeFromInputEvents()
    {
        InputManager.I.OnShootPerformed -= HandleShoot;
    }

    protected virtual void OnDisable()
    {
        UnSusbcribeFromInputEvents();
    }

}
