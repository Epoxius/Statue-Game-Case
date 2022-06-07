using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleController : MonoBehaviour
{
    public AppleState appleState;
    public Rigidbody appleRb;
    public Collider appleCollider;
    public bool isGround;

    public enum AppleState
    {
        Equipped,
        Unequipped
    }

    public void AppleSpawnController()
    {
        var appleGameobject = GameManager.Instance.objectPool.GetPooledObject();
        if (appleGameobject.GetComponent<AppleController>().appleState != AppleState.Unequipped) return;
        appleGameobject.SetActive(true);
        var randomSpawnPoint = Random.Range(0, GameManager.Instance.treeController.treeSpawnPoints.Count);
        appleGameobject.transform.position =
            GameManager.Instance.treeController.treeSpawnPoints[randomSpawnPoint].transform.position;
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("Ground");
            appleRb.useGravity = false;
            appleCollider.isTrigger = true;
        }
        else
        {
            appleRb.useGravity = true;
            isGround = false;
        }

        if (other.gameObject.CompareTag("Chest"))
        {
            Debug.Log("Chest");
            appleState = AppleState.Equipped;
            appleRb.useGravity = true;
            appleCollider.isTrigger = false;
        }

        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            Debug.Log("ChestExit");
            GameManager.Instance.stackManager.chestAppleList.Remove(this.gameObject);
            appleState = AppleState.Unequipped;
            transform.parent = null;
            appleRb.useGravity = true;
        }
        if (other.gameObject.CompareTag("Store"))
        {
            appleState = AppleState.Unequipped;
            this.gameObject.SetActive(false);
            appleRb.useGravity = true;
        }
    }
}