using UnityEngine;

namespace DefaultNamespace.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private MenuWindow _menuWindow;

        public void Initialize()
        {
            _menuWindow.Initialize();
            _gameWindow.Initialize(_menuWindow);
            
            _menuWindow.InitializeButtons(_gameWindow);
        }
    }
}