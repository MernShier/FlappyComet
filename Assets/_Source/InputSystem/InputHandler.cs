using BallSystem;
using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using VContainer;

namespace InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private Ball _ball;
        private GameStateMachine _gameStateMachine;
        private bool _started;

        [Inject]
        private void Construct(Ball ball, GameStateMachine gameStateMachine)
        {
            _ball = ball;
            _gameStateMachine = gameStateMachine;
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Mouse0)) return;

            if (!_started)
            {
                _gameStateMachine.SwitchState(typeof(PlayState));
                _started = true;
            }

            _ball.MoveUp();
        }
    }
}