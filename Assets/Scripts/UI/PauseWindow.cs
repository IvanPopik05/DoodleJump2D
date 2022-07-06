using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class PauseWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private Button _continueBtn;
        [SerializeField] private Button _menuBtn;
        [SerializeField] private Button _quitBtn;

        public void Initialize(IWindow gameWindow)
        {
            _continueBtn.onClick.AddListener(() => gameWindow.Open(this));
            _menuBtn.onClick.AddListener(MainMenu);
            _quitBtn.onClick.AddListener(Quit);
        }

        public void Open(IWindow window = null)
        {
            gameObject.SetActive(true);
            window?.Close();
        }

        public void Close() => 
            gameObject.SetActive(false);

        private void MainMenu() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void Quit() => 
            Application.Quit();
    }
}