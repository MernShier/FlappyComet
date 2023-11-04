using Core.StateMachine;
using Core.StateMachine.States;
using Collision.Data;
using BallSystem;
using ScoreSystem;
using SpawnerSystem;
using UnityEngine;
using Utils;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class MainScope : LifetimeScope
    {
        [SerializeField] private CollisionConfig collisionConfig;
        [SerializeField] private Ball ball;
        [SerializeField] private Spawner spawner;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrapper>();

            builder.RegisterInstance(ball);
            builder.RegisterInstance(spawner);
            builder.RegisterInstance(collisionConfig);

            builder.Register<LevelStartState>(Lifetime.Singleton);
            builder.Register<PlayState>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<Score>(Lifetime.Singleton);
            builder.Register<SceneChanger>(Lifetime.Singleton).WithParameter("foo", 5);
        }
    }
}