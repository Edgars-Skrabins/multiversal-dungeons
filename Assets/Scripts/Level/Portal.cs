using UnityEngine;

public class Portal : MonoBehaviour, IInteractable
{
    public void Interact(Player_Stats _playerStatsCS)
    {
        // Load next room in scene
        GameObject _levelManager = GameObject.Find("LevelManager");
        if (_levelManager != null)
        {
            Debug.Log("Interact with Portal");
            _levelManager.GetComponent<LevelManager>().GoToNextRoom();
        }
        else
        {
            Debug.Log("Level Manager is null you fuck");
        }
    }

    public void InteractGFXOn()
    {
        //Debug.Log("interact portal GFX On");
    }

    public void InteractGFXOff()
    {
        //Debug.Log("interact portal GFX Off");
    }

}
