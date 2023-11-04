using Abstraction;
using Collision.Data;
using UnityEngine;
using Utils.Extensions;
using VContainer;
using Vector3 = UnityEngine.Vector3;

namespace CollectiblesSystem
{
    public abstract class Collectible : TimedMonoBehaviour, IMove
    {
        [SerializeField] protected int value;
        private CollisionConfig _collisionConfig;
        [field: SerializeField] public float MoveSpeed { get; set; }

        [Inject]
        private void Construct(CollisionConfig collisionConfig)
        {
            _collisionConfig = collisionConfig;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                PickUp(col);
            }
        }

        public void Move()
        {
            transform.position += Vector3.left * (MoveSpeed * Time.deltaTime);
        }

        protected virtual void PickUp(Collider2D collector)
        {
            Death();
        }
    }
}