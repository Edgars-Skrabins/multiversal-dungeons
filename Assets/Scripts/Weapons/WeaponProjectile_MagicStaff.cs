using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile_MagicStaff : Weapon_Projectile
{
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
        Debug.Log("Staff Shoot Performed!");
        base.Shoot();
    }
}
