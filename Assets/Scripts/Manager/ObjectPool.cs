using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    // APPLE OBJECT POOL
    
    [SerializeField] Queue<GameObject> pooledObjects;
   
    
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform treeCapacity;

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        for (int j = 0; j < treeCapacity.childCount; j++)
        {
           
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);

            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();

        pooledObjects.Enqueue(obj);

        return obj;
    }
}