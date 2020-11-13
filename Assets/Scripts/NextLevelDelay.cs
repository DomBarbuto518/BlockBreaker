using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDelay : MonoBehaviour
{
    //Config params
    [SerializeField] float splashDelay = 0f;
    [SerializeField] float gameOverDelay = 0f;
    [SerializeField] float winLevelDelay = 0f;

    //Cached references
    MusicPlayer musicPlayer;
    SceneLoader sceneLoader;
    AudioSource musicPlayerAudioSource;
    Ball ball;
    
    void Start()
    {
        //Get handle to music player
        musicPlayer = FindObjectOfType<MusicPlayer>();
        //Get handle to scene loader
        sceneLoader = FindObjectOfType<SceneLoader>();
        //Get handle to the music players audio source component
        musicPlayerAudioSource = musicPlayer.GetComponent<AudioSource>();
        ball = FindObjectOfType<Ball>();


        if (SceneManager.GetActiveScene().name == "SplashMenu")
        {
            //Store length of audio clip
            splashDelay = musicPlayer.splashMusic.length;      
            
            //Start delay to automatically go to next scene after splash music is finished
            StartCoroutine(StartSplashDelay());
        }
        else 
        {
            gameOverDelay = ball.gameOverClip.length;
            winLevelDelay = musicPlayer.winLevelMusic.length;
        }
    }

    /**
     * This method handles the switching of audio clips from background music clip to game over clip and 
     * begins the delay to switch to next scene. The delay = the length of the game over clip.
     * **/
    public void TriggerGameOverSequence()
    {
        musicPlayerAudioSource.loop = false;            //We want game over sound to play just 1 time
        musicPlayerAudioSource.clip = ball.gameOverClip;     //Set components current clip to game over clip
        musicPlayerAudioSource.Play();                  //Play audio source with game over clip set 
        StartCoroutine(StartGameOverDelay());           //Begin delay timer
    }

    public void TriggerNextLevelSequence()
    {
        musicPlayerAudioSource.PlayOneShot(musicPlayer.winLevelMusic);
        StartCoroutine(StartWinLevelDelay());

    }

    public IEnumerator StartSplashDelay()
    {
        yield return new WaitForSeconds(splashDelay - 0.5f);        //Wait for approximate end of splash audio clip
        sceneLoader.LoadStartMenu();                                //Load start menu scene
    }

    public IEnumerator StartGameOverDelay()
    {
        yield return new WaitForSeconds(gameOverDelay);             //Wait for end of game over audio clip 
        sceneLoader.LoadGameOver(); ;                               //Load game over scene
    }

    public IEnumerator StartWinLevelDelay()
    {
        yield return new WaitForSeconds(winLevelDelay);
        sceneLoader.LoadNextLevel();
    }
}
