using System;
using BallSystem;

namespace Core.StateMachine.States
{
    public class LevelStartState : IState
    {
        public event Action<bool> OnLevelStartStatePauseChange;
        private readonly Ball _ball;
        
        private LevelStartState(Ball ball)
        {
            _ball = ball;
        }

        public void Enter()
        {
            _ball.Freeze(true);
            OnLevelStartStatePauseChange?.Invoke(true);
        }

        public void Exit()
        {
            _ball.Freeze(false);
            OnLevelStartStatePauseChange?.Invoke(false);
        }
    }
}