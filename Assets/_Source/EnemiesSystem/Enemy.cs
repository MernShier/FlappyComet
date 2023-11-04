using Abstraction;
using UnityEngine;

namespace EnemiesSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : TimedMonoBehaviour
    {
        protected Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}