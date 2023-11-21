using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [Header("Weapon Settings")]
    [Space(5)]
    [SerializeField] protected float m_fireRateInSeconds;
    [SerializeField] protected Transform[] m_shootLocations;
    [Space(5)]
    
    protected float m_fireRateTimer;
    protected bool m_fireRateZero;

    protected virtual void Awake()
    {
        SusbcribeToInputEvents();
    }
    
    protected virtual void HandleShoot()
    {
        if(CanShoot()) Shoot();
    }

    protected virtual void Shoot()
    {
        ResetFireRateTimer();
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
        }
        return false;
    }

    protected virtual void CountFireRateTimer()
    {
        if(m_fireRateTimer >= 0)
        {
            m_fireRateTimer -= Time.deltaTime;
        }
        else
        {
            m_fireRateZero = true;
        }
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
