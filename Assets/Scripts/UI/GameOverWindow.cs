using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI
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

        private void MainMenu() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void Quit() => 
            Application.Quit();

        public void Open(IWindow window = null)
        {
            gameObject.SetActive(true);
            window?.Close();
        }

        public void Close() => 
            gameObject.SetActive(false);
    }
}