using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class BulletPooler : MonoBehaviour
{
    public static BulletPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // USE THIS code in the object that want to get a pooled object
    // use this instead of instantiating an object
    // feel free to change method, spawn object name
    void useInstance()
    {
        GameObject _object = BulletPooler.SharedInstance.GetPoolObject();
        // add position code
        // add rotation code
        _object.SetActive(true);
    }

    // USE THIS code on the pooled object
    // this should replace any destroy code
    void returnToPool()
    {
        gameObject.SetActive(false);
    }
}
