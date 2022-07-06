using DefaultNamespace.UI;
using Generator_Container;
using Player_Container;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private LevelGeneratorSO _levelGeneratorSo;
        [SerializeField] private GameUI _gameUi;
        [SerializeField] private PlayerController _playerController;
        private void Start()
        {
            //_levelGenerator.Initialize();
            _levelGeneratorSo.Initialize();
            _playerController.Initialize();
            _gameUi.Initialize();
        }
    }
}