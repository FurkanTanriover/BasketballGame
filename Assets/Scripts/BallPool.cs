using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallPool : MonoSingleton<BallPool>
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;

    }

    public int poolCounter;
    public static event Action BallAmountAction;

    [SerializeField] private Pool[] pools = null;


    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab, LevelController.Instance.startPosition.transform.position, Quaternion.identity, transform);
                obj.SetActive(false);
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }

    private void Start()
    {
        GameManager.EndGameEvent += ResetPool;
    }

    public GameObject GetPooledObject(int objectType)
    {
        GameObject obj = pools[objectType].pooledObjects.Dequeue();
        obj.SetActive(true);
        pools[objectType].pooledObjects.Enqueue(obj);
        BallAmountAction?.Invoke();

        return obj;
    }

    public void ResetPool()
    {
        IEnumerator<GameObject> enumerator = pools[0].pooledObjects.GetEnumerator();
        while (enumerator.MoveNext())
        {
            GameObject obj = enumerator.Current;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.GetComponent<SwipeController>().isShoot = false;
            obj.GetComponent<Ball>().ResetBounceCounter();
            obj.SetActive(false);
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        IEnumerator<GameObject> enumerator2 = pools[1].pooledObjects.GetEnumerator();
        while (enumerator2.MoveNext())
        {
            GameObject obj = enumerator2.Current;
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.GetComponent<SwipeController>().isShoot = false;
            obj.GetComponent<Ball>().ResetBounceCounter();
            obj.SetActive(false);
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

}
