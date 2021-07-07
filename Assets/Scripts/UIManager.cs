using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] public GameObject gameEndPanel;
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text amountText;
    [SerializeField] public TMP_Text endPanelScoreText;


    public static event Action OnContinueButtonClicked;
    public static event Action OnStartButtonClicked;

    public int scoreCounter = 0;
  

    private void Start()
    {
        GameManager.EndGameEvent += ShowEndPanel;
        Ball.ScoreAction += ScorePanel;
        BallPool.BallAmountAction += BallAmountPanel;
        amountText.text = "AMOUNT :" + BallPool.Instance.poolCounter.ToString();
        scoreText.text = "SCORE :0";

    }
    public void ContinueButton()
    {
        OnContinueButtonClicked?.Invoke();
    }

    public void StartButton()
    {
        OnStartButtonClicked?.Invoke();
    }

    public void ShowEndPanel()
    {
            gameEndPanel.SetActive(true);
            endPanelScoreText.text = "SCORE :" + scoreCounter.ToString();
    }
  
    public void ShowStartPanel()
    {
        startGamePanel.SetActive(false);
    }

    public void ScorePanel()
    {
        scoreCounter++;
        scoreText.text = "SCORE :" + scoreCounter.ToString();
    }

    public void BallAmountPanel()
    {
        amountText.text = "AMOUNT :" + BallPool.Instance.poolCounter.ToString();
    }
}
