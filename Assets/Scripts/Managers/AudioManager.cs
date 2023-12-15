using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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
    public GameAudio(string _name, AudioClip _audioClip, bool _start, bool _shouldLoop, bool _sfx, bool _music)
    {
        clipName = _name;
        clip = _audioClip;
        playOnStart = _start;
        loop = _shouldLoop;
        isSFX = _sfx;
        isMusic = _music;
    }

    public void InitializeAudioSource(AudioSource _audioSource)
    {
        _audioSource.clip = clip;
        _audioSource.loop = loop;
    }
}

public class AudioManager : Singleton<AudioManager>
{
    //[SerializeField] private ObjectPoolManager.ObjectPool m_audioSourcePool;
    
    public float m_sfxVolume;

    public float m_musicVolume;

    //Audio Manager should be able to
    //TODO: store sounds easily
    //TODO: Play the specific sounds without hassle from anywhere - Done
    //TODO: Play the sounds at a given location
    //TODO: Play the sounds Without a location (therefore always heard)
    //TODO: Automatically play startup sounds


    public List<GameAudio> gameAudioList;

    private void Start()
    {
        foreach (GameAudio gameAudio in gameAudioList)
        {
            if (gameAudio.playOnStart)
            {
                PlaySound(gameAudio.clipName);
            }
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) PlaySound("Shoot");
    }

    public void PlaySound(string _soundName)
    {
        if (GetAudioIfNameValid(_soundName) != null)
        {
            GameObject pooledSource = ObjectPoolManager.I.GetPooledObject("Audio Sources");
            pooledSource.SetActive(true);
            AudioSource aSource = pooledSource.GetComponent<AudioSource>();
            GameAudio audioData = GetAudioIfNameValid(_soundName);

            audioData.InitializeAudioSource(aSource);
            if (audioData.isSFX)
            {
                aSource.volume = m_sfxVolume;
            }
            else
            {
                aSource.volume = m_musicVolume;
            }

            if (audioData.loop)
            {
                aSource.Play();
            }
            else
            {
                StartCoroutine(PlayAndDeactivateResetAudioSourceObjectCo(aSource));
            }
        }
        else
        {
            Debug.LogWarning("Sound does not exist in the dictionary: " + _soundName);
        }
    }

    private GameAudio GetAudioIfNameValid(string soundName)
    {
        for (int i = 0; i < gameAudioList.Count; i++)
        {
            if (gameAudioList[i].clipName == soundName)
                return gameAudioList[i];
        }

        Debug.LogError("Game Audio Not Found! Please Check Name..");
        return null;
    }

    private IEnumerator PlayAndDeactivateResetAudioSourceObjectCo(AudioSource _audioSource)
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
        _audioSource.Stop();
        _audioSource.clip = null;
        _audioSource.gameObject.SetActive(false);
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
            /*
            GUILayout.Space(10);
            EditorGUILayout.LabelField("Volume Control", EditorStyles.boldLabel);

            audioManager.m_musicVolume = EditorGUILayout.Slider("Music Volume", audioManager.m_musicVolume, 0f, 1f);
            audioManager.m_sfxVolume = EditorGUILayout.Slider("SFX Volume", audioManager.m_sfxVolume, 0f, 1f);
            */
        }
    }
#endif
}
