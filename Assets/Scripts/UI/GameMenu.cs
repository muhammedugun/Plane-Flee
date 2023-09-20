using Assets.Scripts.GameManager;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class GameMenu : MonoBehaviour
    {

        
        [SerializeField] internal GameObject pausePanel;
        internal bool isPausePanelActive = false;
        [SerializeField] internal GameObject startPanel;
        [SerializeField] GameController gameController;
        public void PauseButton()
        {
            isPausePanelActive = true;
            GameController.PauseGame();
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