using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SpawnerSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Spawnable> spawnables;
        [Inject] private SpawnablePool _spawnablePool;

        private void Awake()
        {
            FillObjectPools();
            StartSpawner();
        }
        
        private void FillObjectPools()
        {
            foreach (var spawnable in spawnables)
            {
                _spawnablePool.InstantiatePoolObjects(spawnable, spawnable.poolLength);
            }
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

                var objectToSpawn = _spawnablePool.GetPoolObject(spawnable);
                if (objectToSpawn == null) continue;
                
                objectToSpawn.transform.position = spawnable.spawnPoints[Random.Range(0, spawnable.spawnPoints.Count)].position;
                objectToSpawn.SetActive(true);
            }
        }
    }
}