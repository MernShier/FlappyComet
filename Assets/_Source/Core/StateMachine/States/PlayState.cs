using SpawnerSystem;

namespace Core.StateMachine.States
{
    public class PlayState : IState
    {
        private readonly Spawner _spawner;

        private PlayState(Spawner spawner)
        {
            _spawner = spawner;
        }
        
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