using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooter : Weapon_Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        Debug.Log("dart shoot");
        base.Shoot();
    }
}
