using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Loaded Start Menu");
    }

    public void LoadNextLevel()
    {
        //TODO find scene index and add 1 to it
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
