using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class GameManager : MonoSingleton<GameManager>
{

    public bool gameEnded = false;
    public static event Action EndGameEvent;

    [SerializeField] private GameObject scoreObject;

    public float showEndPanelDelay;

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
        StartCoroutine(ShowEndPanelDelay());
    }

    public IEnumerator ShowEndPanelDelay()
    {
        if (gameEnded == false)
        {
            if (BallPool.Instance.poolCounter <= 0)
            {
                yield return new WaitForSeconds(showEndPanelDelay);
                gameEnded = true;
                EndGameEvent?.Invoke();
                Debug.Log("GAME OVER");
            }
        }
    }


    public void NextLevel()
    {
        Debug.Log("Next!!");
        LevelController.Instance.Reset();
        LevelController.Instance.levelCounter++;
    }
}
