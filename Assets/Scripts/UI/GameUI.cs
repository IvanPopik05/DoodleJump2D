using UI.Windows_container;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;

        public void Initialize()
        {
            _gameWindow.Initialize();
        }
    }
}