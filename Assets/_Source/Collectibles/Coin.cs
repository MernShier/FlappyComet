using ScoreSystem;
using UnityEngine;
using Zenject;

namespace Collectibles
{
    public class Coin : Collectible
    {
        [Inject] private Score _score;
        protected override void OnPickUp()
        {
            _score.AddScore(1);
            base.OnPickUp();
        }
    }
}
