using SpawnerSystem;
using VContainer;

namespace Core.StateMachine.States
{
    public class PlayState : IState
    {
        [Inject] private Spawner _spawner;
        
        public void Enter()
        {
            _spawner.StartSpawner();
        }

        public void Exit()
        {
            _spawner.StopSpawner();
        }
    }
}