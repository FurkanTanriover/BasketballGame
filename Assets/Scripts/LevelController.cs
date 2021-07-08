using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    [SerializeField] public List<LevelType> levelList;
    public GameObject startPosition;
    public int levelCounter;
    public int amount;

    private void Awake()
    {
        LevelSetting();
    }
    public void LevelSetting()
    {
        startPosition.transform.position = new Vector3(levelList[levelCounter].startPosition.x, levelList[levelCounter].startPosition.y, levelList[levelCounter].startPosition.z);
        amount = levelList[levelCounter].ballAmount;
    }

    public void Reset()
    {
        UIManager.Instance.ResetScorePanel();
        UIManager.Instance.CloseEndPanel();
    }

    public void CheckLevelCounter()
    {
        if (levelCounter >= levelList.Count - 1)
        {
            levelCounter = 0;
        }
        else
        {
            levelCounter++;
        }
    }

}
