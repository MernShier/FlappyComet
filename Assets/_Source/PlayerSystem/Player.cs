using Core;
using Extensions;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float playerAcceleration;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private LayerMask borderLayer;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
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
            _rb.AddForce(Vector2.up * (playerAcceleration * Time.deltaTime));
        }
        
        private void Death()
        {
            Game.ReloadScene();
        }
    }
}
