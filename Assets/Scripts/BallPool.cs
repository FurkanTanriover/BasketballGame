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
            poolCounter = 1;

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab,LevelController.Instance.startPosition.transform.position, Quaternion.identity, transform);
                obj.SetActive(false);
                poolCounter++;
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= pools.Length)
        {

        }
        GameObject obj = pools[objectType].pooledObjects.Dequeue();
        poolCounter--;
        obj.SetActive(true);
        pools[objectType].pooledObjects.Enqueue(obj);
        Debug.Log("Kalan top sayýsý: " + poolCounter);
        BallAmountAction?.Invoke();

        return obj;
    }


}
