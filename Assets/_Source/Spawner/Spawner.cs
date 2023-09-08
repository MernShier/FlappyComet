using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Spawnable> spawnables;
        [Inject] private DiContainer _diContainer;

        private void Awake()
        {
            StartSpawner();
        }

        private void StartSpawner()
        {
            foreach (var spawnable in spawnables)
            {
                CreatePoolObjects(spawnable);
                StartCoroutine(SpawnObject(spawnable));
            }
        }

        private void CreatePoolObjects(Spawnable spawnable)
        {
            while (spawnable.ObjectPool.Count < spawnable.poolLength)
            {
                var spawnedObject = _diContainer.InstantiatePrefab(spawnable.prefab, Vector3.zero, 
                    quaternion.identity, spawnable.poolParent);
                spawnable.ObjectPool.Add(spawnedObject);
                spawnedObject.SetActive(false);
            }
        }

        private IEnumerator SpawnObject(Spawnable spawnable)
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(spawnable.minSpawnTime, spawnable.maxSpawnTime));

                var objectToSpawn = spawnable.ObjectPool.FirstOrDefault(obj => !obj.activeSelf);
                if (objectToSpawn == null) continue;
                
                objectToSpawn.transform.position = spawnable.spawnPoints[Random.Range(0, spawnable.spawnPoints.Count)].position;
                objectToSpawn.SetActive(true);
            }
        }
    }
}
