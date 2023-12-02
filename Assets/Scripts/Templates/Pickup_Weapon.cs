using UnityEngine;

public class Pickup_Weapon : Pickup
{
    //Use if not picking up Random Weapon
    [SerializeField] private string m_weaponName;
    
    protected override void PickUpItem(Player_Stats _playerStatsCS)
    {
        _playerStatsCS.m_playerWM.EquipWeapon(_playerStatsCS.m_playerWM.GetRandomWeaponName());
    }
}
