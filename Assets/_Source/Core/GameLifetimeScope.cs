using Core.StateMachine;
using Core.StateMachine.States;
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
        [SerializeField] private Spawner spawner;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(player);
            builder.RegisterInstance(spawner);
            
            builder.Register<LevelStartState>(Lifetime.Singleton);
            builder.Register<PlayState>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
            
            builder.Register<Score>(Lifetime.Singleton);
            builder.Register<SpawnablePool>(Lifetime.Singleton);
        }
    }
}
