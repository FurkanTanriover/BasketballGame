using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] public GameObject gameEndPanel;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text amountText;
    [SerializeField] public TMP_Text endPanelScoreText;
    [SerializeField] private GameObject startGamePanel;

    [SerializeField] private List<ParticleSystem> confettiList;

    public static event Action OnContinueButtonClicked;
    public static event Action OnStartButtonClicked;

    public int scoreCounter = 0;

    private void Start()
    {
        GameManager.EndGameEvent += ShowEndPanel;
        Ball.ScoreAction += ScorePanel;
        BallPool.BallAmountAction += BallAmountPanel;
        amountText.text = "AMOUNT :  " + LevelController.Instance.amount;
        scoreText.text = "SCORE :  0";
    }
    public void ContinueButton()
    {
        OnContinueButtonClicked?.Invoke();
    }

    public void StartButton()
    {
        OnStartButtonClicked?.Invoke();
    }

    public void ConfettiPlay()
    {
        for (int i = 0; i < confettiList.Count; i++)
        {
            confettiList[i].Play();
        }
    }
    public void ShowEndPanel()
    {
        gameEndPanel.SetActive(true);
        ConfettiPlay();
        endPanelScoreText.text = "SCORE :  "+ scoreCounter.ToString();
        GameManager.Instance.canShoot = false;
    }

    public void CloseStartPanel()
    {
        startGamePanel.SetActive(false);
        GameManager.Instance.canShoot = true;
    }

    public void ScorePanel()
    {
        scoreCounter++;
        scoreText.text = "SCORE :  " + scoreCounter.ToString();
    }

    public void ResetScorePanel()
    {
        scoreCounter = 0;
        scoreText.text = "SCORE :  " + scoreCounter.ToString();

    }

    public void BallAmountPanel()
    {
        amountText.text = "AMOUNT :  " + LevelController.Instance.amount;
    }

    public void CloseEndPanel()
    {
        gameEndPanel.SetActive(false);
        GameManager.Instance.canShoot = true;
    }
}
