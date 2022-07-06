using Pause_System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Windows_container
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
            PauseManager.Instance.OnPause();
            gameObject.SetActive(true);
            window?.Close();
        }

        public void Close()
        {
            PauseManager.Instance.OnUnpause();
            gameObject.SetActive(false);
        }

        private void MainMenu() => 
            SceneManager.LoadScene(ScenePath.MAIN_MENU_SCENE);

        private void Quit() => 
            Application.Quit();
    }
}