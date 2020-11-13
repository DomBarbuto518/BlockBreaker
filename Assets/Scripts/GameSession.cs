using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //References
    [Header("Game Speed")]
    [SerializeField] private float initialGameSpeed = 1f;
    [SerializeField] private float gameSpeed;

    [Header("Score")]
    [SerializeField] int score;
    [SerializeField] public TextMeshProUGUI scoreTextField;

    [Header("Blocks Remaining")]
    [SerializeField] public int blocksRemaining;
    [SerializeField] public int breakableBlocksRemaining;
    [SerializeField] public int unbreakableBlocksRemaining;
    

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if ((FindObjectsOfType<GameSession>().Length) > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //Set game speed at start
        SetGameSpeed(initialGameSpeed);
    }

    public void SetGameSpeed(float gameSpeed)
    {
        Time.timeScale = gameSpeed;
        this.gameSpeed = gameSpeed;
    }

    public void addToScore(int score)
    {
        this.score += score;
    }

    public void resetScore()
    {
        score = 0;
    }

    public void resetBlockCount()
    {
        blocksRemaining = 0;
        breakableBlocksRemaining = 0;
        unbreakableBlocksRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Update score text
        if (scoreTextField != null)
        {
            scoreTextField.text = score.ToString();
        }
        else
        {
            scoreTextField = FindObjectOfType<TextMeshProUGUI>();
        }
    }
}
