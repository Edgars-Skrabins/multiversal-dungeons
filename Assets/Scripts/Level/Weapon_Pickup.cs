using UnityEngine;

public class Weapon_Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string m_weaponName;
    private Player_Stats m_playerStats;

    private void Start()
    {
        m_playerStats = FindObjectOfType<Player_Stats>();
    }

    public void Interact()
    {
        m_playerStats.m_playerWM.EquipWeapon(m_playerStats.m_playerWM.GetRandomWeaponName());
    }

    public void InteractGFXOff()
    {
        Debug.Log(m_weaponName + "Weapon GFX Off!");
    }

    public void InteractGFXOn()
    {
        Debug.Log(m_weaponName + "Weapon GFX On!");
    }
}
