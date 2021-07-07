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
        SpawnFirstBall();
    }
    public void SpawnBall()
    {
        StartCoroutine(SpawnBallDelay());

    }
    public IEnumerator SpawnBallDelay()
    {
        yield return new WaitForSeconds(spawnDelayTime);
        obj = BallPool.Instance.GetPooledObject(LevelController.Instance.levelList[LevelController.Instance.levelCounter].balltype);
        obj.transform.position = LevelController.Instance.startPosition.transform.position;    
    }

    public void SpawnFirstBall()
    {
        obj = BallPool.Instance.GetPooledObject(LevelController.Instance.levelList[LevelController.Instance.levelCounter].balltype);
        obj.transform.position = LevelController.Instance.startPosition.transform.position;
    }

}
