using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile_DartShooter : Weapon_Projectile
{
    protected override void Shoot()
    {
        Debug.Log("dart shoot");
        base.Shoot();
    }
}
