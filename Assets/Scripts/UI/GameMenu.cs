using Assets.Scripts.GameManager;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class GameMenu : MonoBehaviour
    {

        
        public GameObject pausePanel;
        public GameObject mainPanel;
        public GameObject startPanel;

        internal bool isPausePanelActive = false;

        [SerializeField] private GameController _gameController;
        public void PauseButton()
        {
            isPausePanelActive = true;
            _gameController.PauseGame();
            pausePanel.SetActive(true);
        }

        public void ResumeButton()
        {
            pausePanel.SetActive(false);
            startPanel.SetActive(true);

            UnscaledTimeInvoke.Invoke(IsPausePanelActiveFalse, 0.1f);
        
        }

        public void IsPausePanelActiveFalse()
        {
            isPausePanelActive = false;
        }


        public void RestartButton()
        {
            GameController.RestartGame();
        }
    
        public void MainMenuButton()
        {
            LoadMainMenu();
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }




    }
}