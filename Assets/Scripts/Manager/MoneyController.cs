using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = GameManager.Instance.playerController;
            var store = GameManager.Instance.storeManager;
            transform.parent = player.moneyTransform;
            transform.DOLocalJump(Vector3.zero, 3, 1, 1).OnComplete(() => GameManager.Instance.moneyObjectPool.SetPooledObject(gameObject));
            store.moneyCounter++;
            GameManager.Instance.uiController.moneyText.text = "$ " + store.moneyCounter.ToString();    


        }
    }
}
