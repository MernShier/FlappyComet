using System;
using Collision.Data;
using UnityEngine;
using Utils;
using Utils.Extensions;
using VContainer;

namespace BallSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(ParticleSystem))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float playerAcceleration;
        private CollisionConfig _collisionConfig;
        private SceneChanger _sceneChanger;
        private Rigidbody2D _rigidbody2D;
        private ParticleSystem _particleSystem;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, SceneChanger sceneChanger)
        {
            _collisionConfig = collisionConfig;
            _sceneChanger = sceneChanger;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.EnemyLayer.Contains(col.gameObject.layer) ||
                _collisionConfig.BorderLayer.Contains(col.gameObject.layer))
            {
                Death();
            }
        }

        public void MoveUp()
        {
            _rigidbody2D.AddForce(Vector2.up * (playerAcceleration * Time.deltaTime));
        }

        public void Freeze(bool value)
        {
            if (value)
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Static;
                _particleSystem.Pause();
            }
            else
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                _particleSystem.Play();
            }
        }

        private void Death()
        {
            _sceneChanger.ReloadScene();
        }
    }
}