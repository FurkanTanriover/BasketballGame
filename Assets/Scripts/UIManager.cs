using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] GameObject startGamePanel;
     

    public static event Action OnContinueButtonClicked;
    public static event Action OnStartButtonClicked;

    private void Start()
    {
        GameManager.EndGameEvent += ShowEndPanel;
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
    }

    public void ShowStartPanel()
    {
        startGamePanel.SetActive(false);
    }
}
