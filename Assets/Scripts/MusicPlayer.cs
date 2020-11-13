using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MusicPlayer : MonoBehaviour
{
    //Config params
    [Header("Music Player")]
    [SerializeField] public AudioClip splashMusic;
    [SerializeField] public AudioClip backgroundMusic;
    [SerializeField] public AudioClip winLevelMusic;

    //Cached refs
    AudioSource musicPlayerAudioSource;
    NextLevelDelay nextLevelDelay;

    void Awake()
    {
        SetUpSingleton();
        //Get handle to music players audio source component
        musicPlayerAudioSource = GetComponent<AudioSource>();
        //Get handle to next level delay object
        nextLevelDelay = FindObjectOfType<NextLevelDelay>();
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "SplashMenu")
        {
            PlaySplashMusic();
        }
    }

    public void PlaySplashMusic()
    {
        musicPlayerAudioSource.loop = false;            //No loop for splash scene
        musicPlayerAudioSource.clip = splashMusic;      //Set audio clip
        musicPlayerAudioSource.Play();
        nextLevelDelay.StartSplashDelay();
    }
    public void PlayBackgroundMusic()
    {
        musicPlayerAudioSource.clip = backgroundMusic;
        musicPlayerAudioSource.loop = true;
        musicPlayerAudioSource.Play();
    }

    public void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
