using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoSingleton<GameManager>
{

    public bool gameEnded = false;
    public static event Action EndGameEvent;

    private void Start()
    {
        UIManager.OnContinueButtonClicked += NextLevel;
        UIManager.OnStartButtonClicked += StartGame;
    }

    private void Update()
    {
        EndGame();
    }

    public void StartGame()
    {
        UIManager.Instance.ShowStartPanel();
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            if(BallPool.Instance.poolCounter <= -1)
            {
                gameEnded = true;
                EndGameEvent?.Invoke();
                Debug.Log("GAME OVER");
            }
 
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
