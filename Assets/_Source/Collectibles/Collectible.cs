using System.Collections;
using Extensions;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Collectibles
{
    public abstract class Collectible : MonoBehaviour, IMove, IHaveLifeTime
    {
        [SerializeField] private int value;
        [SerializeField] private LayerMask playerLayer;
        [field:SerializeField] public float MoveSpeed { get; set; }
        [field:SerializeField] public float LifeTime { get; set; }

        private void Awake()
        {
            StartCoroutine(StartLifeTimer(LifeTime));
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (playerLayer.Contains(col.gameObject.layer))
            {
                OnPickUp();
            }
        }
    
        public void Move()
        {
            transform.position += Vector3.left * (MoveSpeed * Time.deltaTime);
        }

        protected virtual void OnPickUp()
        {
            Destroy(gameObject);
        }
    
        public IEnumerator StartLifeTimer(float lifeTime)
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}
