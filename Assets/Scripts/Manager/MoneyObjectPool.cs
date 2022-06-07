using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoneyObjectPool : MonoBehaviour
{
    [SerializeField] Queue<GameObject> pooledObjects;

    [SerializeField] private int moneyInt;

    [SerializeField] private GameObject moneyObjectPrefab;
    [SerializeField] private Transform moneySpawnTransform;
    


    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        for (int j = 0; j < moneyInt; j++)
        {
            
            GameObject moneyObj = Instantiate(moneyObjectPrefab,moneySpawnTransform);
            moneyObj.transform.DOMoveY(moneySpawnTransform.transform.childCount * .3f, 0.5f);  
            moneyObj.SetActive(false);

            pooledObjects.Enqueue(moneyObj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        return obj;
    }

    public void SetPooledObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.parent = transform;
        obj.transform.DOLocalMove(Vector3.down*2, 0);
        pooledObjects.Enqueue(obj);
    }
}