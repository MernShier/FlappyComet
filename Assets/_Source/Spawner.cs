using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class Spawnable
{
    public GameObject prefab;
    public Transform[] spawnPoints;
    public float spawnFrequency;
}


public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnable coins;
    [SerializeField] private Spawnable enemy;

    private readonly Random _rnd = new();

    private void Awake()
    {
        StartCoroutine(SpawnObject(coins));
        StartCoroutine(SpawnObject(enemy));
    }

    private IEnumerator SpawnObject(Spawnable spawnable)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnable.spawnFrequency);
            var spawnPoint = spawnable.spawnPoints[_rnd.Next(0, spawnable.spawnPoints.Length)];
            Instantiate(spawnable.prefab, spawnPoint.position, quaternion.identity, spawnPoint);
        }
    }
}
