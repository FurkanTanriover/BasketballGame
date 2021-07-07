using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    public float zForce;
    public float yForce;

    //[SerializeField] private LevelType levelType = null;
    [SerializeField] public List<LevelType> levelList;
    public GameObject startPosition;
    public int levelCounter;
     
     GameObject obj = null;
    [SerializeField] public float spawnDelayTime;

    private void Awake()
    {

        startPosition.transform.position = new Vector3(levelList[levelCounter].startPosition.x, levelList[levelCounter].startPosition.y, levelList[levelCounter].startPosition.z);
    }
    private void Update()
    {
        LevelSetting();
    }

    public void LevelSetting()
    {
        if (levelCounter == 1)
        {
            startPosition.transform.position = new Vector3(levelList[1].startPosition.x, levelList[1].startPosition.y, levelList[1].startPosition.z);
        }

        else if (levelCounter == 2)
        {
            startPosition.transform.position = new Vector3(levelList[2].startPosition.x, levelList[2].startPosition.y, levelList[2].startPosition.z);
        }

        else if (levelCounter == 3)
        {
            startPosition.transform.position = new Vector3(levelList[3].startPosition.x, levelList[3].startPosition.y, levelList[3].startPosition.z);
        }

        else if (levelCounter == 4)
        {
            startPosition.transform.position = new Vector3(levelList[4].startPosition.x, levelList[4].startPosition.y, levelList[4].startPosition.z);
        }

        else if (levelCounter == 5)
        {
            startPosition.transform.position = new Vector3(levelList[5].startPosition.x, levelList[5].startPosition.y, levelList[5].startPosition.z);
        }

        else if (levelCounter == 6)
        {
            startPosition.transform.position = new Vector3(levelList[6].startPosition.x, levelList[6].startPosition.y, levelList[6].startPosition.z);
        }

        else if (levelCounter == 7)
        {
            startPosition.transform.position = new Vector3(levelList[7].startPosition.x, levelList[7].startPosition.y, levelList[7].startPosition.z);
        }

        else if (levelCounter == 8)
        {
            startPosition.transform.position = new Vector3(levelList[8].startPosition.x, levelList[8].startPosition.y, levelList[8].startPosition.z);
        }

        else if (levelCounter == 9)
        {
            startPosition.transform.position = new Vector3(levelList[9].startPosition.x, levelList[9].startPosition.y, levelList[9].startPosition.z);
        }


    }

    public void Reset()
    {
        UIManager.Instance.amountText.text = "AMOUNT :" + BallPool.Instance.poolCounter.ToString();
        UIManager.Instance.scoreText.text = "SCORE :0";
        UIManager.Instance.endPanelScoreText.text = "SCORE :";
        UIManager.Instance.gameEndPanel.SetActive(false);
        
    }
}
