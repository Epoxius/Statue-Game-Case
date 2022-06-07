using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeController : MonoBehaviour
{
    public float spawnInterval = 1;
    public List<Transform> treeSpawnPoints;
    private void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
          GameManager.Instance.appleController.AppleSpawnController();
          yield return new WaitForSeconds(spawnInterval);
        }
    }
}
