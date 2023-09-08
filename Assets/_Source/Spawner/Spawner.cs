using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Spawnable> spawnables;

        private void Awake()
        {
            StartSpawner();
        }

        private void StartSpawner()
        {
            foreach (var spawnable in spawnables)
            {
                StartCoroutine(SpawnObject(spawnable));
            }
        }

        private IEnumerator SpawnObject(Spawnable spawnable)
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(spawnable.minSpawnTime, spawnable.maxSpawnTime));
                var spawnPoint = spawnable.spawnPoints[Random.Range(0, spawnable.spawnPoints.Length)];
                Instantiate((Object)spawnable.prefab, spawnPoint.position, quaternion.identity, spawnPoint);
            }
        }
    }
}
