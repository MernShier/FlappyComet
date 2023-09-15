using Core;
using Extensions;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(ParticleSystem))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float playerAcceleration;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private LayerMask borderLayer;
        [field:SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field:SerializeField] public ParticleSystem ParticleSystem { get; private set; }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (enemyLayer.Contains(col.gameObject.layer) ||
                borderLayer.Contains(col.gameObject.layer))
            {
                Death();
            }
        }

        public void MoveUp()
        {
            Rigidbody.AddForce(Vector2.up * (playerAcceleration * Time.deltaTime));
        }
        
        private void Death()
        {
            Game.ReloadScene();
        }
    }
}
