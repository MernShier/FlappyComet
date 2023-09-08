using UnityEngine;

namespace Enemies
{
    public class NormalEnemy : Enemy
    {
        [SerializeField] private float minJumpForce;
        [SerializeField] private float maxJumpForce;
        [SerializeField] private float minGravity;
        [SerializeField] private float maxGravity;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            Rb.gravityScale = Random.Range(minGravity, maxGravity);
            Jump();
        }

        private void Jump()
        {
            Rb.AddForce(Vector2.left * Random.Range(minJumpForce, maxJumpForce));
        }
    }
}
