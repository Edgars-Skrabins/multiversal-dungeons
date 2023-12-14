using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class GameAudio
{
    public string clipName; // Name to identify the clip
    public AudioClip clip; // Audio clip reference
    public bool playOnStart; // Should the audio play on game start
    public bool loop; // Should the audio loop
    public bool isSFX; // Is it a sound effect
    public bool isMusic; // Is it music

    // Constructor for initializing the GameAudio object
    public GameAudio(string name, AudioClip audioClip, bool start, bool shouldLoop, bool sfx, bool music)
    {
        clipName = name;
        clip = audioClip;
        playOnStart = start;
        loop = shouldLoop;
        isSFX = sfx;
        isMusic = music;
    }
}

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private ObjectPoolManager.ObjectPool m_audioSourcePool;


    //Audio Manager should be able to
    //TODO: store sounds easily
    //TODO: Play the specific sounds without hassle from anywhere - Done
    //TODO: Play the sounds at a given location
    //TODO: Play the sounds Without a location (therefore always heard)
    //TODO: Automatically play startup sounds

    private Dictionary<string, AudioSource> soundDictionary = new Dictionary<string, AudioSource>();

    public List<GameAudio> gameAudioList;

    private void Start()
    {
        foreach (GameAudio gameAudio in gameAudioList)
        {
            AddSound(gameAudio.clipName, gameAudio.clip, gameAudio.loop);
            if (gameAudio.playOnStart)
            {
                PlaySound(gameAudio.clipName);
            }
        }
    }

    public void AddSound(string soundName, AudioClip clip, bool loop)
    {
        if (!soundDictionary.ContainsKey(soundName))
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.loop = loop;
            soundDictionary.Add(soundName, audioSource);
        }
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            soundDictionary[soundName].Play();
        }
        else
        {
            Debug.LogWarning("Sound does not exist in the dictionary: " + soundName);
        }
    }

    public void PlaySoundAtLocation(string soundName, Vector3 position)
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            AudioSource.PlayClipAtPoint(soundDictionary[soundName].clip, position);
        }
        else
        {
            Debug.LogWarning("Sound does not exist in the dictionary: " + soundName);
        }
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(AudioManager))]
    public class AudioManagerEditor : Editor
    {
        private AudioManager audioManager;

        private void OnEnable()
        {
            audioManager = (AudioManager)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Manage Game Audio", EditorStyles.boldLabel);

            if (GUILayout.Button("Add New Audio Clip"))
            {
                audioManager.gameAudioList.Add(new GameAudio("NewAudioClip", null, false, false, false, false));
            }

            if (audioManager.gameAudioList.Count > 0)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Audio Clips", EditorStyles.boldLabel);

                for (int i = 0; i < audioManager.gameAudioList.Count; i++)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                    audioManager.gameAudioList[i].clip = (AudioClip)EditorGUILayout.ObjectField("Clip", audioManager.gameAudioList[i].clip, typeof(AudioClip), false);
                    audioManager.gameAudioList[i].clipName = EditorGUILayout.TextField("Clip Name", audioManager.gameAudioList[i].clipName);
                    audioManager.gameAudioList[i].playOnStart = EditorGUILayout.Toggle("Play On Start", audioManager.gameAudioList[i].playOnStart);
                    audioManager.gameAudioList[i].loop = EditorGUILayout.Toggle("Loop", audioManager.gameAudioList[i].loop);
                    audioManager.gameAudioList[i].isSFX = EditorGUILayout.Toggle("Is SFX", audioManager.gameAudioList[i].isSFX);
                    audioManager.gameAudioList[i].isMusic = EditorGUILayout.Toggle("Is Music", audioManager.gameAudioList[i].isMusic);

                    if (GUILayout.Button("Remove", GUILayout.Width(60)))
                    {
                        audioManager.gameAudioList.RemoveAt(i);
                        GUIUtility.ExitGUI();
                    }

                    EditorGUILayout.EndVertical();
                }
            }

            GUILayout.Space(10);
            EditorGUILayout.LabelField("Volume Control", EditorStyles.boldLabel);

//            audioManager.musicVolume = EditorGUILayout.Slider("Music Volume", audioManager.musicVolume, 0f, 1f);
//            audioManager.sfxVolume = EditorGUILayout.Slider("SFX Volume", audioManager.sfxVolume, 0f, 1f);
        }
    }
#endif
}
