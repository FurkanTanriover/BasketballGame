using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Spawner : MonoSingleton<Spawner>
{
    GameObject obj = null;
    public float spawnDelayTime;

    private void Start()
    {
        SwipeController.OnShoot += SpawnBall;
        obj = BallPool.Instance.GetPooledObject(LevelController.Instance.levelList[0].balltype);
        obj.transform.position = LevelController.Instance.startPosition.transform.position;
    }
    public void SpawnBall()
    {
        StartCoroutine(SpawnBallDelay());

    }
    public IEnumerator SpawnBallDelay()
    {
        yield return new WaitForSeconds(spawnDelayTime);
        obj = BallPool.Instance.GetPooledObject(LevelController.Instance.levelList[0].balltype);
        obj.transform.position = LevelController.Instance.startPosition.transform.position;    
    }

}
