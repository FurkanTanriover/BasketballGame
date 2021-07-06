using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    public float zForce;
    public float yForce;

    //[SerializeField] private LevelType levelType = null;
    [SerializeField] public List<LevelType> levelList;
    public GameObject startPosition;
    [SerializeField] int levelCounter = 0;
     
     GameObject obj = null;
    [SerializeField] public float spawnDelayTime;

    private void Awake()
    {
        startPosition.transform.position = new Vector3(levelList[0].startPosition.x, levelList[0].startPosition.y, levelList[0].startPosition.z);
       
    }

    public void LevelSetting(int level)
    {
  
        

    }


}
