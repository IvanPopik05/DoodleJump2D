using System;
using Input_System;
using Pause_System;
using UnityEngine;

namespace Player_Container
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _movementSpeed = 3f;

        private PlayerBorders _playerBorders;
        private IInput _inputService;
        private float _movement;
        public bool IsPaused => PauseManager.Instance.IsPaused;

        public void Initialize(IInput inputService)
        {
            _inputService = inputService;
            _inputService.Pressed += OnPressed;
            _playerBorders = new PlayerBorders();
        }

        private void OnPressed(float movement) => 
            _movement = movement * _movementSpeed;

        private void Update()
        {
            if(IsPaused)
                return;
            
            _inputService.UpdateInput();
            transform.position = _playerBorders.CheckBorderPositionX(transform);
        }

        private void FixedUpdate()
        {
            if(IsPaused)
                return;
            
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.x = _movement;
            _rigidbody2D.velocity = velocity;
        }
    }
}