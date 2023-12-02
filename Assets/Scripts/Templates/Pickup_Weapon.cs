using UnityEngine;

public class Pickup_Weapon : Pickup
{
    /// <summary>
    /// Leave Weapon Name Blank To Give Random Weapon
    /// </summary>
    [SerializeField] private string m_weaponName;
    
    protected override void PickUpItem(Player_Stats _playerStatsCS)
    {
        if(m_weaponName == "")
            _playerStatsCS.m_playerWM.EquipWeapon(_playerStatsCS.m_playerWM.GetRandomWeaponName());
        else
            _playerStatsCS.m_playerWM.EquipWeapon(m_weaponName);
    }
}
