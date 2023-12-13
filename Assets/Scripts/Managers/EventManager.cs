using System;

public class EventManager : Singleton<EventManager>
{

    public event Action OnPlayerInteraction;
    public event Action OnRoomCleared;
}
