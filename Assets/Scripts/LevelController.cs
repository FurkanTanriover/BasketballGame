using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    public float zForce;
    public float yForce;

    [SerializeField] public List<LevelType> levelList;
    public GameObject startPosition;
    public int levelCounter;
     
     GameObject obj = null;

    private void Awake()
    {
        startPosition.transform.position = new Vector3(levelList[levelCounter].startPosition.x, levelList[levelCounter].startPosition.y, levelList[levelCounter].startPosition.z);
    }
    public void LevelSetting()
    {
        startPosition.transform.position = new Vector3(levelList[levelCounter].startPosition.x, levelList[levelCounter].startPosition.y, levelList[levelCounter].startPosition.z);
        Spawner.Instance.SpawnBall();
    }

    public void Reset()
    {
        UIManager.Instance.scoreText.text = "SCORE :0";
        UIManager.Instance.endPanelScoreText.text = "SCORE :";
        UIManager.Instance.gameEndPanel.SetActive(false);
        
    }
}
