using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace SpawnerSystem
{
    public class SpawnablePool
    {
        [Inject] private DiContainer _diContainer;

        public void InstantiatePoolObjects(Spawnable spawnable, int number)
        {
            while (number > 0)
            {
                var spawnedObject = _diContainer.InstantiatePrefab(spawnable.prefab, Vector3.zero, 
                    quaternion.identity, spawnable.poolParent);
                spawnable.ObjectPool.Add(spawnedObject);
                spawnedObject.SetActive(false);
                number--;
            }
        }

        public GameObject GetPoolObject(Spawnable spawnable) =>
            spawnable.ObjectPool.FirstOrDefault(obj => !obj.activeSelf);
    }
}