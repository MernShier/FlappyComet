using PlayerSystem;
using ScoreSystem;
using SpawnerSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Player player;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrapper>();
            
            builder.RegisterInstance<Player>(player);
            
            builder.Register<Score>(Lifetime.Singleton);
            builder.Register<SpawnablePool>(Lifetime.Singleton);
        }
    }
}
