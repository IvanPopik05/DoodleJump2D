using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _quitBtn;

        public void Start()
        {
            _quitBtn.onClick.AddListener(Quit);
            _startGameBtn.onClick.AddListener(StartGame);
        }
        private void Quit() => 
            Application.Quit();

        private void StartGame() => 
            SceneManager.LoadScene(ScenePath.GAME_SCENE);
    }
}