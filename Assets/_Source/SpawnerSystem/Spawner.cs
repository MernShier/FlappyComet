using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
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
        }
        
        private void FillObjectPools()
        {
            foreach (var spawnable in spawnables)
            {
                _spawnablePool.InstantiatePoolObjects(spawnable, spawnable.poolLength);
            }
        }

        public void StartSpawner()
        {
            foreach (var spawnable in spawnables)
            {
                StartCoroutine(SpawnObject(spawnable));
            }
        }

        public void StopSpawner()
        {
            StopAllCoroutines();
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