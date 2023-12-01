using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string m_WeaponName;
    public string GetWeaponName() { return m_WeaponName; }


    private void Start()
    {
        
    }

    public void Interact()
    {
        Debug.Log(m_WeaponName + "Weapon Equipped!");
    }

    public void InteractGFXOff()
    {
        Debug.Log(m_WeaponName + "Weapon GFX Off!");
    }

    public void InteractGFXOn()
    {
        Debug.Log(m_WeaponName + "Weapon GFX On!");
    }
}
