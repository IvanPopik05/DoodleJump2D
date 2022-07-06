using Pause_System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Windows_container
{
    public class GameOverWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private Button _menuBtn;
        [SerializeField] private Button _quit;
        public void Initialize()
        {
            _menuBtn.onClick.AddListener(MainMenu);
            _quit.onClick.AddListener(Quit);
        }

        public void Open(IWindow window = null)
        {
            PauseManager.Instance.OnPause();
            gameObject.SetActive(true);
            window?.Close();
        }

        public void Close() => 
            PauseManager.Instance.OnUnpause();

        private void MainMenu() => 
            SceneManager.LoadScene(ScenePath.MAIN_MENU_SCENE);

        private void Quit() => 
            Application.Quit();
    }
}