using UnityEngine;

public abstract class Weapon_Hitscan : Weapon
{

    [Header("Hitscan Settings")]

    [SerializeField] private int m_weaponDamage;
    [SerializeField] private GameObject m_bulletImpactVFX;

    protected override void Shoot()
    {
        Vector2 mousePosition = InputManager.I.GetWorldMousePosition();
        Vector2 playerToMouse = mousePosition - (Vector2)m_playerStatsCS.PlayerTF.position;

        RaycastHit2D hit = Physics2D.Raycast(m_shootLocations[0].position, playerToMouse);

        if(hit)
        {
            if(hit.collider.TryGetComponent(out Enemy_Health healthCS))
            {
                healthCS.TakeDamage(m_weaponDamage);
            }

            if (m_bulletImpactVFX)
            {
                PlayImpactVFX(hit.transform);
            }
        }

        base.Shoot();
    }

    void PlayImpactVFX(Transform _impactTF)
    {
        if (!m_bulletImpactVFX) return;

        float vfxOffsetFromWall = 0.1f;

        var obj = Instantiate(m_bulletImpactVFX, _impactTF.position, _impactTF.rotation);
        Transform objTF = obj.transform;

        // Player position for direction to player
        Vector3 playerDir = GameManager.I.GetPlayerTransform().position - objTF.position;
        objTF.position += playerDir * vfxOffsetFromWall;
    }

}
