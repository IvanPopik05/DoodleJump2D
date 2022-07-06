using Generator_Container;
using Pause_System;
using Player_Container;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private GameUI _gameUi;

        private void Start()
        {
            _levelGenerator.Initialize();
            _playerController.Initialize();
            _gameUi.Initialize();
        }
    }
}