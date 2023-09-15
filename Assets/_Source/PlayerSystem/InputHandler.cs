using System;
using Core;
using Core.StateMachine;
using Core.StateMachine.States;
using UnityEngine;
using VContainer;

namespace PlayerSystem
{
    public class InputHandler : MonoBehaviour
    {
        [Inject] private Player _player;
        [Inject] private GameStateMachine _gameStateMachine;

        private bool _gameStarted;
    
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                _player.MoveUp();
            
                if (_gameStarted) return;
                _gameStateMachine.SwitchState(typeof(PlayState));
                _gameStarted = true;
            }
        }
    }
}