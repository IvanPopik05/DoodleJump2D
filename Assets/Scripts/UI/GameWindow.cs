using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class GameWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private GameOverWindow _gameOverWindow;
        [SerializeField] private PauseWindow _pauseWindow;
        
        [SerializeField] private Button _restartBtn;
        [SerializeField] private Button _pauseBtn;

        public GameOverWindow GetGameOverWindow() => _gameOverWindow;
        
        public void Initialize(IWindow menuWindow)
        {
            _gameOverWindow.Initialize();
            _pauseWindow.Initialize(this);
            IsActiveElements(false);
            _restartBtn.onClick.AddListener(() => Restart(menuWindow));
            _pauseBtn.onClick.AddListener(() => _pauseWindow.Open());
        }

        private void Restart(IWindow window)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Open(window);
        }

        public void Open(IWindow window = null)
        {
            IsActiveElements(true);
            gameObject.SetActive(true);
            window?.Close();
        }

        public void Close()
        {
            IsActiveElements(false);
            gameObject.SetActive(false);
        }

        private void IsActiveElements(bool isActive)
        {
        }
    }
}