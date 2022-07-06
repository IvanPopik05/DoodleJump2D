using System;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Player_Container
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private PlayerMove _playerMove;
        public void Initialize()
        {
            _playerMove.Initialize();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Border _border))
            {
                _gameWindow.GetGameOverWindow().gameObject.SetActive(true);
            }
        }
    }
}