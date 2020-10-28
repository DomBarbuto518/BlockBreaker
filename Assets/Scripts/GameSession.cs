using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private float initialGameSpeed = 1f;

    [SerializeField] private float gameSpeed;

    private void Awake()
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
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = initialGameSpeed;

        gameSpeed = initialGameSpeed;
    }

    public void SetGameSpeed(float gameSpeed)
    {
        Time.timeScale = gameSpeed;
        this.gameSpeed = gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
