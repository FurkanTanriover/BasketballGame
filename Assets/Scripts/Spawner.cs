using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Spawner : MonoSingleton<Spawner>
{
    GameObject obj = null;
    public float spawnDelayTime;

    private void Start()
    {
        SwipeController.OnShoot += SpawnNewBall;
        SpawnBall();
    }
    public void SpawnNewBall()
    {
        StartCoroutine(SpawnNewBallDelay());

    }
    public IEnumerator SpawnNewBallDelay()
    {
        yield return new WaitForSeconds(spawnDelayTime);
        obj = BallPool.Instance.GetPooledObject(LevelController.Instance.levelList[LevelController.Instance.levelCounter].balltype);
        obj.transform.position = LevelController.Instance.startPosition.transform.position;    
    }

    public void SpawnBall()
    {
        obj = BallPool.Instance.GetPooledObject(LevelController.Instance.levelList[LevelController.Instance.levelCounter].balltype);
        obj.transform.position = LevelController.Instance.startPosition.transform.position;
    }

}
