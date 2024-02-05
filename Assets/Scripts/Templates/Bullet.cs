using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] protected Player_Stats m_playerStatsCS;

    [Header("Bullet Settings")]
    [SerializeField] protected int m_bulletDamage;
    [SerializeField] protected float m_bulletSpeed;
    [SerializeField] protected bool m_lifeTimeDestroy;
    [SerializeField] protected float m_bulletLifeTime;
    [SerializeField] protected bool m_doesSlow;
    protected float m_despawnTimer;

    [Space(20)]
    [Header(" ----- Bullet ImpactVFX Settings -----")]
    [SerializeField] protected string m_impactSFX;
    [Space(5)]

    [SerializeField] protected bool m_hasImpactVFX;
    [SerializeField] protected GameObject m_bulletImpactVFX;


    [Space(20)]
    [SerializeField] protected Rigidbody2D m_bulletRB;
    [SerializeField] protected Transform m_bulletTF;

    protected virtual void Start()
    {
        LaunchBullet();
    }

    protected virtual void Update()
    {
        if (m_lifeTimeDestroy)
        {
            CountBulletLifetimeDestroy();
        }
    }

    protected virtual void CountBulletLifetimeDestroy()
    {
        m_despawnTimer += Time.deltaTime;
        if (m_despawnTimer >= m_bulletLifeTime)
        {
            m_despawnTimer = 0;
            Destroy(gameObject);
        }
    }

    protected virtual void LaunchBullet()
    {
        m_bulletRB.velocity = (m_bulletTF.position - InputManager.I.GetWorldMousePosition()) * -m_bulletSpeed;
    }

    protected virtual void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(!otherCollider.CompareTag("Player_Collider"))
            Impact(otherCollider);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("Player_Collider"))
            Impact(collision.collider);
    }

    protected virtual void Impact(Collider2D _otherCollider)
    {
        Health health = _otherCollider.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(m_bulletDamage);
            //if(_otherCollider.CompareTag("Enemy") && m_doesSlow)
            //{
            //    health.Slow();
            //}
        }

        if (m_hasImpactVFX) PlayImpactVFX();
        //TODO: Add ImpactSFX
        //AudioManager.I.Play(m_impactSFX);

        Destroy(gameObject);
    }

    protected virtual void PlayImpactVFX()
    {
        if(!m_bulletImpactVFX) return;

        float vfxOffsetFromWall = 0.1f;
        
        var obj = Instantiate(m_bulletImpactVFX, m_bulletTF.position, m_bulletTF.rotation);
        Transform objTF = obj.transform;

        // Player position for direction to player
        Vector3 playerDir = GameManager.I.GetPlayerTransform().position - objTF.position;
        objTF.position += playerDir * vfxOffsetFromWall;
    }

    public virtual void SetOwner(Player_Stats _playerStatsCS)
    {
        m_playerStatsCS = _playerStatsCS;
    }

}
