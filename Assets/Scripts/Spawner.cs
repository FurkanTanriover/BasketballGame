using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Spawner : MonoSingleton<Spawner>
{
    GameObject obj = null;

    public float spawnDelayTime;

    private void Start()
    {
        BallPool.Instance.GetPooledObject(0);
        SwipeController.OnShoot += SpawnBall;
    }
    private void Update()
    {

    }
    public void SpawnBall()
    {
        StartCoroutine(SpawnBallDelay());

    }

    public IEnumerator SpawnBallDelay()
    {
        yield return new WaitForSeconds(spawnDelayTime);
        obj = BallPool.Instance.GetPooledObject(0);
        obj.transform.position = BallPool.Instance.spawnPoint.transform.position;

       
    }

}
