using MultiversalDungeons.Utilities;
using UnityEngine;

public abstract class Weapon_Hitscan : Weapon
{

    [Header("Hitscan Settings")]

    [SerializeField] private int m_weaponDamage;

    protected override void Shoot()
    {
        // TODO: Shoot raycast towards mouse position, the calculation is probably wrong cause it uses Vector3 to Vector2 conversions

        Vector2 mousePosition = InputManager.I.GetWorldMousePosition();
        Vector2 playerToMouse = mousePosition - (Vector2)m_playerStatsCS.m_playerTF.position;

        RaycastHit2D hit = Physics2D.Raycast(m_shootLocations[0].position, playerToMouse);

        if(hit)
        {
            if(hit.collider.TryGetComponent(out Health healthCS))
            {
                healthCS.TakeDamage(m_weaponDamage);
            }
        }

        base.Shoot();
    }

}
