using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [Header("Weapon Settings")]
    [Space(5)]
    protected float m_fireRateInSeconds;
    protected float m_fireRateTimer;

    protected virtual void Awake()
    {
        SusbcribeToInputEvents();
    }

    protected virtual void HandleShoot()
    {
        
    }

    protected virtual void Shoot()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void CountFireRateTimer()
    {
        throw new System.NotImplementedException();
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
