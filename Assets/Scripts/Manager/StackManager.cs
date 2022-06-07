using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform appleChestPoint;
    public List<GameObject> chestAppleList = new List<GameObject>();

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            
            var apple = other.gameObject.transform;
            chestAppleList.Add(apple.gameObject);
            apple.SetParent(appleChestPoint);
            apple.DOLocalJump(Vector3.zero, 3, 1, 1);


        }

        if (other.gameObject.CompareTag("Store"))
        {
            for (int i = 0; i < chestAppleList.Count; i++)
            {
                var appleList =  chestAppleList[i].transform;
                appleList.parent = null;
                appleList.DOLocalJump(GameManager.Instance.storeManager.transform.position, 3,1,1);

            }
        }

        
    }
}