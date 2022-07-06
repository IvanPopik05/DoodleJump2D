using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Windows_container
{
    public class GameWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private GameOverWindow _gameOverWindow;
        [SerializeField] private PauseWindow _pauseWindow;
        
        [SerializeField] private Button _restartBtn;
        [SerializeField] private Button _pauseBtn;

        public GameOverWindow GetGameOverWindow() => _gameOverWindow;
        
        public void Initialize()
        {
            _gameOverWindow.Initialize();
            _pauseWindow.Initialize(this);
            _restartBtn.onClick.AddListener(Restart);
            _pauseBtn.onClick.AddListener(() => _pauseWindow.Open());
        }

        public void Open(IWindow window = null)
        {
            gameObject.SetActive(true);
            window?.Close();
        }

        public void Close() => 
            gameObject.SetActive(false);

        private void Restart() => 
            SceneManager.LoadScene(ScenePath.GAME_SCENE);
    }
}