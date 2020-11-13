using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    MusicPlayer musicPlayer;
    GameSession gameSession;

    public void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void Restart()
    {
        gameSession.resetScore();
        gameSession.resetBlockCount();
        //Destroy(musicPlayer);
        //Destroy(gameSession);
        //SceneManager.LoadScene("SplashMenu");
        LoadStartMenu();
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");

        if(FindObjectOfType<GameSession>())
        {
            Destroy(FindObjectOfType<GameSession>());
        }

        musicPlayer.PlayBackgroundMusic();
        Debug.Log("Loaded Start Menu");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene("Level01");
        Debug.Log("Loaded Level 01");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Loaded Game Over");
    }

    public void QuitApplication()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
