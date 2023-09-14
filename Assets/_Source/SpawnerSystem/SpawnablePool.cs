using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SpawnerSystem
{
    public class SpawnablePool
    {
        [Inject] private IObjectResolver _iObjectResolver;
        public void InstantiatePoolObjects(Spawnable spawnable, int number)
        {
            while (number > 0)
            {
                var spawnedObject = _iObjectResolver.Instantiate(spawnable.prefab, Vector3.zero, 
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