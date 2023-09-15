using System;
using PlayerSystem;
using UnityEngine;
using VContainer;

namespace Core.StateMachine.States
{
    public class LevelStartState : IState
    {
        [Inject] private Player _player;
        public event Action<bool> OnLevelStartPauseChange;

        public void Enter()
        {
            _player.Rigidbody.bodyType = RigidbodyType2D.Static;
            _player.ParticleSystem.Pause();
            OnLevelStartPauseChange?.Invoke(true);
        }

        public void Exit()
        {
            _player.Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _player.ParticleSystem.Play();
            OnLevelStartPauseChange?.Invoke(false);
        }
    }
}