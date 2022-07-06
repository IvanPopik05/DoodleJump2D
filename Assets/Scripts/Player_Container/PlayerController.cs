using System;
using Input_System;
using UI;
using UI.Windows_container;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Player_Container
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private PlayerMove _playerMove;

        private IInput _inputService;
        public void Initialize()
        {
            _inputService = GetInputDevice();
            _playerMove.Initialize(_inputService);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Border _border))
            {
                _gameWindow.GetGameOverWindow().Open();
                Destroy(gameObject);
            }
        }
        private IInput GetInputDevice()
        {
            if (Application.isEditor) 
                return new DesktopInput();
            
            return new MobileInput();
        }
    }
}