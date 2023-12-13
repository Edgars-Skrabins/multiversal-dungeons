using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private ObjectPoolManager.ObjectPool pool;
    //Audio Manager should be able to
    //TODO: store sounds easily
    //TODO: Play the specific sounds without hassle from anywhere
    //TODO: Play the sounds at a given location
    //TODO: Play the sounds Without a location (therefore always heard)
    //TODO: Automatically play startup sounds
}
