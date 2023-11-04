using Core.StateMachine;
using Core.StateMachine.States;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : IStartable
    {
        private readonly GameStateMachine _gameStateMachine;
        
        private Bootstrapper(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void Start()
        {
            _gameStateMachine.SwitchState(typeof(LevelStartState));
        }
    }
}