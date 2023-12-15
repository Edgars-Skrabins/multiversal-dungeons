using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public void Interact(Player_Stats _playerStatsCS)
    {
        PickUpItem(_playerStatsCS);
    }

    public void InteractGFXOff()
    {
    }

    public void InteractGFXOn()
    {
    }

    protected abstract void PickUpItem(Player_Stats _playerStatsCS);

}