using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SpawnerSystem.Data
{
    [Serializable]
    public class Spawnable
    {
        [field:SerializeField] public GameObject Prefab { get; private set; }
        [field:SerializeField] public int PoolLength { get; private set; }
        [field:SerializeField] public Transform PoolParent { get; private set; }
        [field:SerializeField] public List<Transform> SpawnPoints { get; private set; }
        [field:SerializeField] public float MinSpawnTime { get; private set; }
        [field:SerializeField] public float MaxSpawnTime { get; private set; }
        private List<GameObject> _spawnedObjects = new();

        public void InstantiatePoolObjects(IObjectResolver iObjectResolver)
        {
            var count = PoolLength;
            while (count > 0)
            {
                var spawnedObject = iObjectResolver.Instantiate(Prefab, Vector3.zero,
                    quaternion.identity, PoolParent);
                _spawnedObjects.Add(spawnedObject);
                spawnedObject.SetActive(false);
                count--;
            }
        }

        public GameObject GetPoolObject() =>
            _spawnedObjects.FirstOrDefault(obj => !obj.activeSelf);
    }
}