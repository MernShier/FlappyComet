using UnityEngine;

namespace Collision.Data
{
    [CreateAssetMenu(fileName = "CollisionConfigSO", menuName = "SO/BallSystem/CollisionConfigSO")]
    public class CollisionConfig : ScriptableObject
    {
        [field:SerializeField] public LayerMask BallLayer { get; private set; }
        [field:SerializeField] public LayerMask EnemyLayer { get; private set;}
        [field:SerializeField] public LayerMask CollectibleLayer { get; private set;}
        [field:SerializeField] public LayerMask BorderLayer { get; private set;}
    }
}