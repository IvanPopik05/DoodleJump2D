using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class MenuWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _quitBtn;
        public void Initialize() => 
            _quitBtn.onClick.AddListener(Quit);

        public void Open(IWindow window)
        {
            gameObject.SetActive(true);
            window.Close();
        }

        public void Close() => 
            gameObject.SetActive(false);

        private void Quit() => 
            Application.Quit();

        public void InitializeButtons(GameWindow gameWindow)
        {
            _startGameBtn.onClick.AddListener(() => gameWindow.Open(this));
        }
    }
}