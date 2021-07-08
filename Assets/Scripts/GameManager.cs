using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class GameManager : MonoSingleton<GameManager>
{
    public static event Action EndGameEvent;
    public float showEndPanelDelay;
    public bool canShoot = false;
    private void Awake()
    {
        UIManager.OnContinueButtonClicked += NextLevel;
        UIManager.OnStartButtonClicked += StartGame;
    }

    public void StartGame()
    {
        UIManager.Instance.CloseStartPanel();
    }

    public bool CheckEndGame()
    {
        if (LevelController.Instance.amount <= 0)
        {
            StartCoroutine(ShowEndPanelDelay());
            return true;
        }
        return false;
    }

    public IEnumerator ShowEndPanelDelay()
    {
        yield return new WaitForSeconds(showEndPanelDelay);
        EndGameEvent?.Invoke();
    }

    public void NextLevel()
    {
        LevelController.Instance.CheckLevelCounter();
        LevelController.Instance.Reset();
        LevelController.Instance.LevelSetting();
    }

}
