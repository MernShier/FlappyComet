namespace Collectibles
{
    public class Coin : Collectible
    {
        protected override void OnPickUp()
        {
            Score.Instance.AddScore(1);
            base.OnPickUp();
        }
    }
}
