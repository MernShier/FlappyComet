using ScoreSystem;
using VContainer;

namespace Collectibles
{
    public class Coin : Collectible
    {
        [Inject] private Score _score;
        protected override void OnPickUp()
        {
            _score.AddScore(value);
            base.OnPickUp();
        }
    }
}
