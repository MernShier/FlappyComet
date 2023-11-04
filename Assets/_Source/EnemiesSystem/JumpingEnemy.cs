using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemiesSystem
{
    public class JumpingEnemy : Enemy
    {
        [SerializeField] private float minJumpForce;
        [SerializeField] private float maxJumpForce;
        [SerializeField] private float minGravity;
        [SerializeField] private float maxGravity;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            Rigidbody2D.gravityScale = Random.Range(minGravity, maxGravity);
            Jump();
        }

        private void Jump()
        {
            Rigidbody2D.AddForce(Vector2.left * Random.Range(minJumpForce, maxJumpForce));
        }
    }
}