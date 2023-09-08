using System;
using UnityEngine;

namespace Spawner
{
    [Serializable]
    public class Spawnable
    {
        public GameObject prefab;
        public Transform[] spawnPoints;
        public float minSpawnTime;
        public float maxSpawnTime;
    }
}