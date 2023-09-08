using PlayerSystem;
using ScoreSystem;
using SpawnerSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Player player;
        
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
            
            Container.Bind<Score>().AsSingle().NonLazy();
            Container.Bind<SpawnablePool>().AsSingle().NonLazy();
        }
    }
}