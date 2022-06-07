using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public int moneyIndex;
    public int moneyCounter;
   

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            moneyIndex++;
            GameManager.Instance.moneyObjectPool.GetPooledObject();
            
        }
    }
}
