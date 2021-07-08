using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoSingleton<Spawner>
{
    [SerializeField] private float spawnDelayTime;

    GameObject obj = null;

    private void Start()
    {
        SwipeController.OnShoot += SpawnNewBall;
        UIManager.OnContinueButtonClicked += SpawnNewBall;
        SpawnBall();
    }
    public void SpawnNewBall()
    {
        if (LevelController.Instance.amount != 0)
        {
            StartCoroutine(SpawnNewBallDelay());
        }
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
