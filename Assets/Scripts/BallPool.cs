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

    private void Start()
    {
        GameManager.EndGameEvent += ResetPool;

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

    public void ResetPool()
    {
        for(int i=0;i<pools[0].pooledObjects.Count;i++)
        {
            GameObject obj = pools[0].pooledObjects.Dequeue();
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        for (int i = 0; i < pools[1].pooledObjects.Count; i++)
        {
            GameObject obj = pools[1].pooledObjects.Dequeue();
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

}
