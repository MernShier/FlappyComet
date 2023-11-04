using System.Collections;
using System.Collections.Generic;
using SpawnerSystem.Data;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace SpawnerSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Spawnable> spawnables;
        private IObjectResolver _iObjectResolver;

        [Inject]
        private void Construct(IObjectResolver iObjectResolver)
        {
            _iObjectResolver = iObjectResolver;
        }
        
        private void Awake()
        {
            FillObjectPools();
        }
        
        private void FillObjectPools()
        {
            foreach (var spawnable in spawnables)
            {
                spawnable.InstantiatePoolObjects(_iObjectResolver);
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
            foreach (var spawnable in spawnables)
            {
                StopCoroutine(SpawnObject(spawnable));
            }
        }

        private IEnumerator SpawnObject(Spawnable spawnable)
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(spawnable.MinSpawnTime, spawnable.MaxSpawnTime));

                var objectToSpawn = spawnable.GetPoolObject();
                if (objectToSpawn == null) continue;
                
                objectToSpawn.transform.position = spawnable.SpawnPoints[Random.Range(0, spawnable.SpawnPoints.Count)].position;
                objectToSpawn.SetActive(true);
            }
        }
    }
}