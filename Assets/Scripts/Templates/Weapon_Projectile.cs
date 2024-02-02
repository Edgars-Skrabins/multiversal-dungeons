using UnityEngine;

public abstract class Weapon_Projectile : Weapon
{
    [Header("Projectile Settings")]

    [SerializeField] private GameObject[] m_bulletProjectilePrefabs;

    protected override void Shoot()
    {
        SpawnProjectile();
        base.Shoot();
    }

    protected virtual void SpawnProjectile()
    {
        foreach(GameObject projectile in m_bulletProjectilePrefabs)
        {
            GameObject bullet = Instantiate(projectile,m_shootLocations[0].position, m_playerStatsCS.transform.rotation);
            if(bullet.TryGetComponent(out Bullet bulletCS))
            {
                bulletCS.SetOwner(m_playerStatsCS);
            }
        }
    }

}