using ScoreSystem;
using UnityEngine;
using VContainer;

namespace CollectiblesSystem
{
    public class Coin : Collectible
    {
        private Score _score;

        [Inject]
        private void Construct(Score score)
        {
            _score = score;
        }

        protected override void PickUp(Collider2D collector)
        {
            _score.AddScore(value);
            base.PickUp(collector);
        }
    }
}