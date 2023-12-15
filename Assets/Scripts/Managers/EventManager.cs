using System;

public class EventManager : Singleton<EventManager>
{

    public event Action OnPlayerInteraction;
    public event Action OnRoomCleared;
    public void Invoke_OnRoomCleared()
    {
        OnRoomCleared?.Invoke();
    }

    public event Action OnGamePaused;
    public void Invoke_OnGamePaused()
    {
        OnGamePaused?.Invoke();
    }

    public event Action OnGameUnpaused;
    public void Invoke_OnGameUnpaused()
    {
        OnGameUnpaused?.Invoke();
    }

}
