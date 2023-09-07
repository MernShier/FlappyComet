using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Spawnable
{
    public GameObject prefab;
    public Transform[] spawnPoints;
    public float minSpawnTime;
    public float maxSpawnTime;
}


public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnable coin;
    [SerializeField] private Spawnable enemy;

    private void Awake()
    {
        StartSpawner();
    }

    private void StartSpawner()
    {
        StartCoroutine(SpawnObject(coin));
        StartCoroutine(SpawnObject(enemy));
    }

    private IEnumerator SpawnObject(Spawnable spawnable)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnable.minSpawnTime, spawnable.maxSpawnTime));
            var spawnPoint = spawnable.spawnPoints[Random.Range(0, spawnable.spawnPoints.Length)];
            Instantiate(spawnable.prefab, spawnPoint.position, quaternion.identity, spawnPoint);
        }
    }
}
