using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{

    public event Action OnPlayerInteraction;
    public event Action OnRoomCleared;

}
