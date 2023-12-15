using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [Serializable]
    public class ObjectPool
    {
        public string name; // The name of the pool for calling an object from outside this script
        [Space(10)]
        [HideInInspector] public List<GameObject> pooledObjects;
        [Tooltip("The object that will be pooled")]
        public GameObject pooledObject; //The pooled object
        [Tooltip("The amount of times the object will be pooled")]
        public int pooledAmount; //The amount of objects in this pool
        [Tooltip("If willGrow is on then the list will dynamically grow when out of objects to call")]
        public bool willGrow; // If the list is dynamically going to get bigger or not
        [Tooltip("If dontDestroyOnLoad is on then the object this class is on and the pooled objects wont be destroyed when changing scenes")]
        public bool dontDestroyOnLoad;
    }

    public ObjectPool[] objectPools;

    private void Start()
    {
        InitializeGOLists();
    }

    private void InitializeGOLists()
    {
        // ----- Makes a list for each of the aray list variables ----- 

        foreach(var t in objectPools)
        {
            t.pooledObjects = new List<GameObject>();
        }

        // ----- Instantiates objects,enables the DontDestroyOnLoad and adds them to the list -----

        foreach(var t1 in objectPools)
        {
            for (int t = 0; t < t1.pooledAmount; t++)
            {
                GameObject obj = Instantiate(t1.pooledObject);
                if(t1.dontDestroyOnLoad)
                {
                    DontDestroyOnLoad(obj);
                }

                obj.SetActive(false);
                t1.pooledObjects.Add(obj);
            }
        }
    }

    /// <summary> 
    /// Use this function when you need to get an object from one of the object pools
    /// </summary>
    /// <param name="name"> Name of the pool array indexed class that you can find in the inspector </param>
    /// <returns> Returns a GameObject that is not active and enabled in the given object pool</returns>
    /// <example> GameObject obj = PoolerScript.Pooler.GetPooledObject(); </example>
    /// 
    public GameObject GetPooledObject(string name)
    {
        // ----- Returns a GameObject -----
        ObjectPool op = Array.Find(objectPools, ObjectPools => ObjectPools.name == name);

        foreach(GameObject t in op.pooledObjects)
        {
            if (!t.activeInHierarchy)
            {
                return t;
            }
        }       

        // ----- Spawns a new object if willgrow is true and if there are not enough objects in the list -----

        if(op.willGrow != true) return null;
        GameObject obj = Instantiate(op.pooledObject);
        op.pooledObjects.Add(obj);
        return obj;

        // If willGrow is false and there isnt enough objects it returns null to not cause an error
    }
}