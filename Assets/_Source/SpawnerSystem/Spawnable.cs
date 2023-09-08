using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnerSystem
{
    [Serializable]
    public class Spawnable
    {
        public GameObject prefab;
        public int poolLength;
        public Transform poolParent;
        public List<Transform> spawnPoints;
        public float minSpawnTime;
        public float maxSpawnTime;
        public List<GameObject> ObjectPool { get; private set; } = new();
    }
}