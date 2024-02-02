using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitscan_DartShooter : Weapon_Hitscan
{
    [SerializeField] private string m_shootSFXName = "Shoot";

    private void OnDisable()
    {
        InputManager.I.OnShootPerformed -= Shoot;
    }
    private void OnEnable()
    {
        InputManager.I.OnShootPerformed += Shoot;
    }
    protected override void Shoot()
    {
        Debug.Log("Dart Shoot Performed!");
        base.Shoot();

        if (m_shootSFXName != string.Empty)
        { AudioManager.I.PlaySound(m_shootSFXName); }
    }
}
