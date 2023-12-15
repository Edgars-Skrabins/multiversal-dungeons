using System;
using UnityEngine;

public class Player_WeaponManager : MonoBehaviour
{
    [Serializable]
    public class Weapon
    {
        public string m_WeaponName;

        public GameObject m_WeaponGO;
    }

    public Weapon[] m_Weapons;

    [HideInInspector] public string m_currentWeaponName;

     protected void Awake()
     {
         //m_currentWeaponName = m_Weapons[0].m_WeaponName;
         //EquipWeapon(m_currentWeaponName);
     }
    
     public void EquipWeapon(string _weaponName)
     {
         m_currentWeaponName = _weaponName;
    
         foreach (var weapon in m_Weapons)
         {
             if (weapon.m_WeaponName == _weaponName)
             {
                 weapon.m_WeaponGO.SetActive(true);
             }
             else
             {
                 weapon.m_WeaponGO.SetActive(false);
             }
         }

        Debug.Log("Equipepd Weapon:" + m_currentWeaponName);

     }
    
     [ContextMenu("EquipRandomWeapon")]
     public void EquipRandomWeapon()
     {
         int rand = UnityEngine.Random.Range(0, m_Weapons.Length);
    
         if (m_currentWeaponName == m_Weapons[rand].m_WeaponName)
         {
             if (m_Weapons.Length == 1)
             {
                 return;
             }
    
             if (rand + 1 >= m_Weapons.Length)
             {
                 rand -= 1;
             }
             else if (rand - 1 < 0)
             {
                 rand += 1;
             }
             else
             {
                 rand += 1;
             }
         }
    
    
         EquipWeapon(m_Weapons[rand].m_WeaponName);
        Debug.Log("Equipepd Random Weapon:" + m_Weapons[rand].m_WeaponName);
    }
    
    //public void ShowNextWeaponIcon(string _weaponName)
    //{
    //    foreach (var weapon in m_Weapons)
    //    {
    //        if (weapon.m_WeaponName == _weaponName)
    //        {
    //            weapon.m_weaponIcon.SetActive(true);
    //        }
    //        else
    //        {
    //            weapon.m_weaponIcon.SetActive(false);
    //        }
    //    }
    //}
    
     public string GetRandomWeaponName()
     {
         int rand = UnityEngine.Random.Range(0, m_Weapons.Length);
    
         if (m_currentWeaponName == m_Weapons[rand].m_WeaponName)
         {
             if (m_Weapons.Length == 1)
             {
                 return null;
             }
    
             if (rand + 1 >= m_Weapons.Length)
             {
                 rand -= 1;
             }
             else if (rand - 1 < 0)
             {
                 rand += 1;
             }
             else
             {
                 rand += 1;
             }
         }
    
         return m_Weapons[rand].m_WeaponName;
    
     }
    
}